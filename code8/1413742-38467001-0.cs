        public int Create(BusinessObjects.Application businessApplication)
            {
                DataObjects.Application dataApplication = Mapper.Map<BusinessObjects.Application, DataObjects.Application>(businessApplication);
                int count = 0;
                using (CreditCardPreQualificationEntities CreditCardPreQualificationDatabase = new CreditCardPreQualificationEntities())
                {
                    CreditCardPreQualificationDatabase.Applications.Add(dataApplication);
                    count = CreditCardPreQualificationDatabase.SaveChanges();
                }
                return count;
            }
