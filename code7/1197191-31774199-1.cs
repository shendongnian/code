        [HttpPost]
        public ActionResult SavePost(Post post)
        {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("index");
        }
