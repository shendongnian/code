    try
     { 
         db.SaveChanges();
     }
     catch (DbUpdateException ex)
     {
     }
    catch (DbUpdateConcurrencyException ex)
     {
     }
