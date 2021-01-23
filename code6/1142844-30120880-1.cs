    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    namespace amrcadpWebDev.Controllers
    {
        /// <summary>
        /// File Controller
        /// </summary>
        public class FileController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
            #region Action
            [HttpPost]
            public virtual ActionResult FileUpload(HttpPostedFileBase File)
            {
                bool isUploaded = false;
                string message = "File upload failed";
                if (ModelState.IsValid)
                {
                    if (File != null && File.ContentLength != 0 )
                    {
                        string pathForSaving = "\\\\*****\\FileStore\\resultsFiles\\";
                        string fname = Path.Combine(pathForSaving, File.FileName);
                        try
                        {
                            File.SaveAs(Path.Combine(pathForSaving, File.FileName));
                            isUploaded = true;
                            message = "File uploaded successfully!";
                        }
                        catch (Exception ex)
                        {
                            message = string.Format("File upload failed!!: {0} {1}", ex.Message, fname);
                        }
                    }
                    return Json(new { isUploaded = isUploaded, message = message }, "text/html");
                }
                return View();
            }
            #endregion
        }   
    }
