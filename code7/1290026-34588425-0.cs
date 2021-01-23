    public class FileUploadController : Controller
     {
         //
         // GET: /FileUpload/
    
         public ActionResult Index()
         {
             return View();
         }
         public ActionResult UploadFile()
         {
             var httpPostedFileBase = Request.Files["FileName"];
             if (httpPostedFileBase != null && httpPostedFileBase.ContentLength > 0)
             {
                 string extension = System.IO.Path.GetExtension(httpPostedFileBase.FileName);
                 string path1 = string.Format("{0}/{1}", Server.MapPath("~/SavedFiles"),  extension);
                 if (System.IO.File.Exists(path1))
                     System.IO.File.Delete(path1);
     
                 httpPostedFileBase.SaveAs(path1);
             }
             ViewData["Status"] = "Success";
             return View("Index");
         }
     }
