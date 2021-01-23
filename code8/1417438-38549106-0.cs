    using (ContexManager contex = new ContexManager())
                {
         var company = contex.Companies.Where(c => c.MyKeyId == companyId).Single();
            Row = contex.Companies.Where(c => c.MyKeyId == KeyId).Single();
                    Unit Row = new Unit()
                    {
                        MyCode = Code,
                        MyName = Name,
                        MyDescription = Description,
                        ModifiedUserId = ModifiedUserId,
                        ModificationDate = ModificationDate,
                        Company = company,
                        DeleteFlag = 0
                    };
                    contex.units.Add(Row);
                    contex.SaveChanges();
                }
