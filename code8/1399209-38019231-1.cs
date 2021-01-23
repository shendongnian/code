    using NewDeploymentsTesting.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace NewDeploymentsTesting.Controllers
    {
        public class HomeController : Controller
        {
            // GET: Home
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpPost]
            public ContentResult UploadFiles()
            {
                var r = new List<UploadFilesResult>();
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    if (hpf.ContentLength == 0) continue;
                    string savedFileName = Path.Combine(Server.MapPath("~/Content/Resource"), Path.GetFileName(hpf.FileName));
                    hpf.SaveAs(savedFileName);
                    r.Add(new UploadFilesResult()
                    {
                        Name = hpf.FileName,
                        Length = hpf.ContentLength,
                        Type = hpf.ContentType
                    });
                }
                return Content("{\"name\":\"" + r[0].Name + "\",\"type\":\"" + r[0].Type + "\",\"size\":\"" + string.Format("{0} bytes", r[0].Length) + "\"}", "application/json");
            }
        }
    }
