    public class YourController:Controller{
      [HttpPost]
       publiction ActionResult UploadFiles(){
            if (Request.Files != null && Request.Files.Count > 0)
            {              
              string path=Server.MapPath("~/App_Data");
              Request.Files[0].SaveAs(path + fileName);
          return Json("File uploaded","text/json",JsonRequestBehavior.AllowGet);
            }
          return Json("No File","text/json",JsonRequestBehavior.AllowGet);
       }
    }
