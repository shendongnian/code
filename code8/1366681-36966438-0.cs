        public static IList<PatientEntity> GetPatientFromDatabase(string firstName, 
                        string lastName)
        {
            ISessionFactory sessionForTests = 
                   NHibernateConfig.CreateSessionFactory(Database.TEST_DB_NAME);
            using (ISession session = sessionForTests.OpenSession())
            {
                return session.QueryOver<PatientEntity>()
                    .Where(k => k.FirstName == firstName && k.LastName == lastName)
                    .Fetch(x => x.Appointments).Eager
                    .TransformUsing(Transformers.DistinctRootEntity).List();
            }
        }
