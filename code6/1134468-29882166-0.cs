        public ActionResult Index()
        {
            Dictionary<int, string> postImages = new Dictionary<int, string>();
            var posts = db.Posts.Where(p => p.BlogUserEmail == User.Identity.Name).Include(p => p.BlogUser).Include(p => p.Category);
            foreach (var item in posts) 
            {
                byte[] buffer = item.Picture;
                postImages.Add(item.ID, Convert.ToBase64String(buffer));
            }
            ViewBag.Images = postImages;
            return View(posts.ToList());
        }
