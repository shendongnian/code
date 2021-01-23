    public class PostViewModel()
    {
         public string Id {get;set;}
         public string Title {get;set;}
         public string Summary {get;set;}
         public string Content {get;set;}
    }
    public ActionResult Edit(PostViewModel viewModel)
    {
        if (ModelState.IsValid) {
            var newsPost = db.Posts.Find(post.Id);
            ...
            db.Entry(newsPost).CurrentValues.SetValues(viewModel);
            ...
        }
    }
