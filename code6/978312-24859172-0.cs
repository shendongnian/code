    try
    {
        context.SaveChanges();
    }
    catch(Exception ex)
    {
        try
            {
                foreach (var eve in ((DbEntityValidationException)ex).EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            catch
            {
            }
        }
    }
