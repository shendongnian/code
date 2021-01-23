            foreach (var item in g)
                    {
                        db.Set<Grade>().Attach(item);
                        db.Entry<Grade>(item).State = EntityState.Modified;
                        db.Configuration.ValidateOnSaveEnabled = false;
                    }
                    db.SaveChanges();
