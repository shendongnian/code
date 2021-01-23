    public class HomeController : Controller
    {
        public static string tmpFilePath, filename, path;
        // some other methods...
        [HttpGet]
        public ActionResult UploadToFlickr()
        {
            // This method will probably get called back by Flickr
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UploadToFlickr(HttpPostedFileBase file, FormCollection form)
        {
            // This method will only be called when the user clicks the upload button
            tmpFilePath = Server.MapPath("~/App_Data/Uploads/Pictures");
            if (file == null || file.ContentLength == 0)
            {
                // No file was provided...show validation errors or something
            }
            filename = Path.GetFileName(file.FileName);
            path = Path.Combine(tmpFilePath, filename);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            file.SaveAs(path);
            if (Request.QueryString["oauth_verifier"] != null && Session["RequestToken"] != null)
            {
                // Flickr relevant code...
                string photoId = flickr.UploadPicture(path, "Test picture");
            }
            else
            {
                // Flickr relevant code...
                string url = flickr.OAuthCalculateAuthorizationUrl(token.Token, AuthLevel.Write);
                Response.Redirect(url);
            }
            return View("Test");
        }
    }
