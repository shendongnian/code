    using (var db = new YourDb())
                {
                    try
                    {
                        db.Entry(user).State = EntityState.Modified;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    db.SaveChanges();
                    return true;
                }
