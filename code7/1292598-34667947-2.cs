    public ActionResult View(int? id)
    {
       if(id!=null)  // id came in the request
       {
          int postId= id.Value;
          var postViewModel = new PostViewModel { Id=postId};
          // Use postId to get your entity/View model from db and then return view
          // The below is the code to get data from Db. 
          // Read further if your data access method is different.
          var db = new MyDbContext()
          
          var post=db.Posts.FirstOrDefault(x=>x.Id==postId);
          if(post!=null)
          {
              postViewModel.Title = post.Title;
              return View(postViewModel);
          }
          return View("PostNotFound"); // Make sure you have this view.
       }
       //If code reaches here, that means no id value came in request.
       return RedirectToAction("Index");
    }
