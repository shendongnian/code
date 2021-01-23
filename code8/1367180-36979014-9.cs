    public class YourController : Controller 
    {
        public ActionResult YourView(int id)
        {
            var model = new YourModel();
            var image = db.GetImage(id);
            model.Id = id;
            model.ImageB64 = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(image));
            return View(model);
        }
    }
