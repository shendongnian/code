    public ActionResult MainDetails(string urlslug)
    {
        Post post = db.Posts.First(m => m.UrlSlug == urlslug);
        List<Post> posts = db.Posts.ToList();
        PostViewModel model = new PostViewModel
        {
             CurrentPost = post,
             Posts = posts
        };
        if (post == null)
        {
            return HttpNotFound();
        }
        return View(model);
    }
