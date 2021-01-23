     //// find your model 
     var entity = db.Models.Find(id);
     entity.Name=modelDTO.Name; 
     /// set modified property
     db.Entry(entity).Property(c => c.status).IsModified = true     
     await db.SaveChangesAsync();
