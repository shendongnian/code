    public ActionResult Index()
        {
            try
            {
                return View(db.Tickets.ToList());
            }
            catch (System.Data.Entity.ModelConfiguration.ModelValidationException ex)
            {
               
                throw new DbEntityValidationException(ex.Message, ex.InnerException);
            }
            
        }
