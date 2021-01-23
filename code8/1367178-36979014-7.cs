    public class ImageController : Controller 
    {
        public ActionResult GetImage(int i)
        {
            byte[] bytes = db.GetImage(i); //Get the image from your database
            return File(bytes, "image/png"); //or "image/jpeg", depending on the format
        }
    }
