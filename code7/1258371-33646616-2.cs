    if (!p.Any())
                {
                    Ref_Cantact = new Cantact();
                    Ref_Cantact.Cantact1 = Name;
                    Ref_Cantact.Number = Num;
                    using(var trans=Contex.Database.BeginTransaction())
                    {
                        Contex.Database.ExecuteSqlStatement("SET IDENTITY_INSERT Contact ON;");
                        Contex.Cantacts.Add(Ref_Cantact);
                        Contex.SaveChanges();
                        trans.Commit();
                    }
                }
