    public ActionResult Index(Categories category)
        {
            using (var db = new DoskaUsContext())
            {
                foreach (var cat in category)
                {
                    category.Count = 25;
                    db.Entry(category).State = EntityState.Modified;
                }
                db.SaveChanges();
                return View();               
            }
        }
 
