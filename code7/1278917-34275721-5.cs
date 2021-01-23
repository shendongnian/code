    [HttpPost]
    public ActionResult Create(CreatePostViewModel model)
    {
       if (ModelState.IsValid)
       {
         // To get the files, access model.BlogImage & model.BlogLogo properties  
         using(var db=new YourDbContext())
         {
           var customer = new Customer();
           customer.Name = model.CustomerName;
           //Set other property values as well
           var blog = new BlogPost();
           blog.Title = model.Title;
           blog.Customer = customer;
           //Set other property values as well
    
           db.Blogs.Add(blog);
           db.SaveChanges();
         }
       }
       return View(model);
    }
