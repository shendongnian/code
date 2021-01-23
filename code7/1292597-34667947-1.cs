    public ActionResult View(int? id)
    {
       if(id!=null)
       {
          int postId= id.Value;
          // use int to get your entity/View model from db and then return view
          var db = new MyDbContext();
          var post=db.Posts.FirstOrDefault(x=>x.Id==postId);
          if(post!=null)
          {
            var postViewModel = new PostViewModel { Id=postId};
            postViewModel.Title = post.Title;
            return View(postViewModel);
          }
          return View("PostNotFound"); // Make sure you have this view.
       }
       return RedirectToAction("Index");
    }
