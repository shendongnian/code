    using (DBEntities context = new DBEntities())
            {
                foreach (var singular in plural)
                {
                    context.EntitiDB.Add(singular); 
                }
                context.SaveChanges();
            }
