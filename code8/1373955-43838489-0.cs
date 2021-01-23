        public class PagesController : Controller
        {
            // Regular ID-based routing
            [Route("pages/{id}")]
            public ActionResult Detail(int? id)
            {
                if(id == null)
                {
                    return new HttpNotFoundResult();
                }
                
                var model = myContext.Pages.Single(x => x.Id == id);
                if(model == null)
                {
                    return new HttpNotFoundResult();
                }
                ViewBag.Title = model.Title;
                return View(model);
            }
            
            // Slug-based routing - reuse View from above controller.
            public ActionResult DetailSlug (string slug)
            {
                if (string.IsNullOrEmpty(slug))
                {
                    RedirectToAction("Index", "Home");
                }
    
                var model = MyDbContext.Pages.SingleOrDefault(x => x.Slug == slug);
                if(model == null)
                {
                    return new HttpNotFoundResult();
                }
                ViewBag.Title = model.Title;
                return View("Detail", model);
            }
        }
