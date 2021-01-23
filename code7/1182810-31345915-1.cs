    public class ImageController : Controller
    {
        private ImageDBContext db = new ImageDBContext();
        public ActionResult Index(int intValue){
        var imagesId = db.Images.Where(img -> img.ID == intValue).ToList();
        return View(imagesId);
        }
    }
