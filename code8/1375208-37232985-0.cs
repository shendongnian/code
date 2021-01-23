    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Save();
        event EventHandler Added;
        event EventHandler Commited;
        void OnAdded(RepositoryActionEventArgs<T> eventArgs);
        void OnCommited(RepositoryActionEventArgs<T> eventArgs);
    }
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime Registered { get; set; }
    }
    public enum RepositoryAction
    {
        Create = 0,
        Read = 1,
        Update = 2,
        Delete = 3,
        Commit = 4
    }
    public class RepositoryActionEventArgs<T> : EventArgs where T : class
    {
        public RepositoryActionEventArgs(RepositoryAction action, T entity)
        {
            Entity = entity;
            ActionExecuted = action;
        }
        public T Entity { get; private set; }
        public RepositoryAction ActionExecuted { get; private set; }
    }
    public class ConcreteRepository : IRepository<User>
    {
        public void Add(User entity)
        {
            _context.Somethings.Add(entity);
            OnAdded(new RepositoryActionEventArgs<User>(RepositoryAction.Create, entity));
        }
        public void Save()
        {
            _context.SaveChanges();
            OnCommited(new RepositoryActionEventArgs<User>(RepositoryAction.Commit, null));
        }
        public virtual void OnAdded(RepositoryActionEventArgs<User> eventArgs)
        {
            EventHandler handler = Added;
            if (handler == null)
                return;
            handler(this, eventArgs);
        }
        public virtual void OnCommited(RepositoryActionEventArgs<User> eventArgs)
        {
            EventHandler handler = Commited;
            if (handler == null)
                return;
            handler(this, eventArgs);
        }
        public event EventHandler Added;
        public event EventHandler Commited;
    }
