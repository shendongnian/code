        public ActionResult Index()
        {
            var posts = new List<MvcApplication2.Models.Post>();
            foreach (var item in posts) // this is wrong 
            {
                byte[] buffer = item.Picture;
                item.ImageToShow = Convert.ToBase64String(buffer);
            }
            return View(posts.ToList());
        }
