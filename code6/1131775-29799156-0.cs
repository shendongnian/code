    using NHibernate;
    using NHibernate.Linq;
    
    public class EntityManager<T> {
        private ISession _session;
    
        public EntityManager(ISession session) {
            _session = session;
        }
    
        public IQueryable<T> GetAllClients() {
            return _session.Query<T>();
        }
    }
