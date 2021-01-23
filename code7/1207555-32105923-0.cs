        private static readonly ISessionFactory sessionFactory;
        static SessionManager()
        {
            sessionFactory = new DatabaseConfiguration().BuildSessionFactory();
        }
        public static ISession GetCurrentSession()
        {
            if (CurrentSessionContext.HasBind(sessionFactory))
            {
                return sessionFactory.GetCurrentSession();
            }
            var session = sessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
            return session;
        }
        public static void Unbind()
        {
            CurrentSessionContext.Unbind(sessionFactory);
        }
    }
