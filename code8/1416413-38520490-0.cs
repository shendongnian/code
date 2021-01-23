    using (var db = new YourContext())
    {
        using (var t = db.Database.BeginTransaction()) 
        {
            try
            {
                var like = db.Likes.Find(id);
    
                if (like == null)
                {
                    Like like = new Like("SomeData", UserPosedLike);    
                    db.Add(like);
                }
                else 
                {
                    db.Likes.Remove(like);
                }
    
                db.SaveChanges();
    
                t.Commit();
            }
            catch
            {
                t.Rollback();
            }
        }
    }
