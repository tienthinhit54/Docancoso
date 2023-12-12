using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Docancoso.Models;

namespace Docancoso.Controllers
{
    public class TelephoneController : Controller
    {
        // GET: Telephone
        dbTelephoneDataDataContext data = new dbTelephoneDataDataContext();
        private List<SANPHAM> Layspmoi(int count)
        {
            //Sắp xếp sách theo ngày cập nhật, sau đó lấy top @count 
            return data.SANPHAMs.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var spmoi = Layspmoi(5);
            return View(spmoi);
        }
        public ActionResult Details(int id)
        {
            var sp = from s in data.SANPHAMs
                       where s.Masp == id
                       select s;
            return View(sp.Single());
        }
    }
}