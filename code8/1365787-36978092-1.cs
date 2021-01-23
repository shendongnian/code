          public void UpdateLastReviewCreationDate(string idBusiness, DateTime LastReviewCreationDate,string urlSite) {
                DAL.Business bu;
                try {
                    using (DBContext tpContext = new DBContext())
                    {
                        bu = tpContext.business.Find(idBusiness, urlSite);
                        DAL.Site siteE = bu.site;
                        if (bu != null)
                        {
                            bu.LastReviewCreationDate = LastReviewCreationDate;
                            bu.site = siteE;
                            tpContext.SaveChanges();
                        }
                    }
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
