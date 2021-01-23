    using System.Web;
    using System.Web.Mvc;
    namespace UploadExample.Controllers
    {
        public class UploadController : Controller
        {
            public ActionResult File(HttpPostedFileBase file)
            {
                file.SaveAs(@"c:\FilePath\" + file.FileName);
            }
        }
    }
