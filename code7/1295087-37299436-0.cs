            try
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                //loop through your updates here
            }
            finally
            {
                db.Configuration.AutoDetectChangesEnabled = true;
            }
            db.SaveChanges();
