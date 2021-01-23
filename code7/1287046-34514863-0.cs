        using System.IO;
        using System.Web;
        using System.Web.Mvc;
        using Spire.Doc;
        using Spire.Doc.Collections;
    
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpPost]
            public ActionResult Index(HttpPostedFileBase file)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);
    
                    var outputPath = Path.Combine(Server.MapPath("~/App_Data/copies"), fileName);
    
                    var sourceDoc = new Document(path);
                    var destinationDoc = new Document();
                    foreach (Section sec in sourceDoc.Sections)
                    {
                        var newSection = destinationDoc.AddSection();
                        foreach (DocumentObject obj in sec.Body.ChildObjects)
                        {
                            newSection.Body.ChildObjects.Add(obj.Clone());
                        }
                    }
                    destinationDoc.SaveToFile(outputPath, FileFormat.Docx);
                }
    
                return View();
            }    
        }
