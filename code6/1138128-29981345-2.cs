    private ApplicationDbContext db = new ApplicationDbContext();
        
    public ActionResult ViewPost(int? id = 1) 
    {              
        if (id == null)
        {
             return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        else 
            {
                Post post = db.Posts.Find(id);
                return View(post);
            }
                
       }
