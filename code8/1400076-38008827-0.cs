       public ActionResult Deletefunction(Part model)
        {
            try
            {
                using (dbContext db = new dbContext())
                {
                    Part del = db.Parts.Where(c => c.id == model.PartId).FirstOrDefault();
                    // Changed from Delete to update
                    del.Active = 0;
                    db.SaveChanges();
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
    
        }
