    IList<NewsImagesViewModel> newsImagesList;
    using (DbContext dbContext = new DbContext())
    {
       newsImagesList = dbContext.News
           .Select(n => new NewsImagesViewModel
           {
               Title = n.Title,
               Images = n.Images,
               // ... some other properties you may need
           }
           .ToList();                                        
     }
     return View(newsImagesList);
