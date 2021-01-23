    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    
    namespace WebApplication2.Controllers
    {
        //public class CampaignViewModel
        //{
        //    public string ImageData { get; set; }
        //}
    
        public class CampaignController : Controller
        {
            // GET: Campaign
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpPost]
            public ActionResult SaveImage()
            {
                int len = (int)Request.InputStream.Length;
                byte[] buffer = new byte[len];
                int c = Request.InputStream.Read(buffer, 0, len);
                string png64 = Encoding.UTF8.GetString(buffer, 0, len);
                byte[] png = Convert.FromBase64String(png64);
                System.IO.File.WriteAllBytes("d:\\a.png", png);
                //string pngz = Encoding.UTF8.GetString(png, 0, png.Length);
                //code.....
                return RedirectToAction("Index", "Home");
            }
            //
        }
    }
