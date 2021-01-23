     private void Save(User newEntity,int someId)
        {
            InteractionsDBContext db = new InteractionsDBContext();            
            EntityFramework.User oldEntity = db.Users.Find(someId);
            if (oldEntity == null)
            {
                db.Users.Add(newEntity);
                db.SaveChanges();
            }
            else
            {                
                newEntity.UserId = oldEntity.UserId; //giving the Id of the old entity, in order to update
                db.Entry(oldEntity).State = EntityState.Detached;
                db.Users.Attach(newEntity); 
                db.Entry(newEntity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
