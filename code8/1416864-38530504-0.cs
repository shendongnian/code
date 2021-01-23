            foreach (var item in g)
                    {
                        db.Set<tblInsuredDetail>().Attach(item);
                        db.Entry<tblInsuredDetail>(item).State = EntityState.Modified;
                        db.Configuration.ValidateOnSaveEnabled = false;
                    }
                    db.SaveChanges();
