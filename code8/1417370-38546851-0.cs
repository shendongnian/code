    try {
     Context.Content.Add(content);
     Context.SaveChanges();
    } catch (DbEntityValidationException e) {
     foreach(var eve in e.EntityValidationErrors) {
      Console.WriteLine("Entity  \"{0}\" exceptions \"{1}\" :", eve.Entry.Entity.GetType().Name, eve.Entry.State);
      foreach(var ve in eve.ValidationErrors) {
       Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
      }
     }
    }
