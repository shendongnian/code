    public class Repo : IDisposable
    {
        private ISessionFactory sessionFactory;
        private ISession session;
        public Repo(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
            this.session = sessionFactory.OpenSession();
            session.Disconnect();
        }
        public void Dispose()
        {
            try
            {
                session.Dispose();
            }
            finally
            {
                sessionFactory.Dispose();
            }
        }
        public void Save(Entity entity)
        {
            using (Connection connection = new Connection(session))
            using (ITransaction t = session.BeginTransaction())
            {
                session.Save(entity);
                t.Commit();
            }
        }
        public IList<T> GetList<T>() where T : Entity
        {
            using (Connection connection = new Connection(session))
            {
                return session.QueryOver<T>().List();
            }
        }
        private class Connection : IDisposable
        {
            private ISession session;
            internal Connection(ISession session)
            {
                this.session = session;
                session.Reconnect();
            }
            public void Dispose()
            {
                session.Disconnect();
            }
        }
    }
