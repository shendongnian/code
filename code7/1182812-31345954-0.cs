    public class ImageController : Controller
        {
            private ImageDBContext db = new ImageDBContext();
              public ActionResult Index()
            {
                [.. some code to decide the id ..]
                return View(db.Images
                  .Where(x => x.ID = [myId]
                  .ToList());
            }
