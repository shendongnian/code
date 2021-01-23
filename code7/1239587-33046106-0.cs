    public class EventListener : IPreInsertEventListener, IPreUpdateEventListener
    {
        private readonly IStamper _stamper;
        public EventListener() : this(new Stamper()) { }
        public EventListener(IStamper stamper)
        {
            _stamper = stamper;
        }
        #region IPreInsertEventListener Members
        public bool OnPreInsert(PreInsertEvent @event)
        {
            _stamper.Insert(@event.Entity as IStampedEntity, @event.State, @event.Persister);
            return false;
        }
        #endregion
        #region IPreUpdateEventListener Members
        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            _stamper.Update(@event.Entity as IStampedEntity, @event.OldState, @event.State, @event.Persister);
            return false;
        }
        #endregion
    }
    public interface IStamper
    {
        void Insert(IStampedEntity entity, object[] state, IEntityPersister persister);
        void Update(IStampedEntity entity, object[] oldState,  object[] state, IEntityPersister persister);
    }
    public class Stamper : IStamper
    {
        private const String CreateUser = "CreateUser";
        private const String CreateDate = "CreateDate";
        private const String LastUpdateUser = "LastUpdateUser";
        private const String LastUpdateDate = "LastUpdateDate";
        public void Insert(IStampedEntity entity, object[] state, IEntityPersister persister)
        {
            if (entity == null)
                return;
            SetCreate(entity, state, persister);
            SetChange(entity, state, persister);
        }
        public void Update(IStampedEntity entity, object[] oldState, object[] state, IEntityPersister persister)
        {
            if (entity == null)
                return;
            SetChange(entity, state, persister);
        }
        private void SetCreate(IStampedEntity entity, object[] state, IEntityPersister persister)
        {
            entity.CreateUser = GetUserName();
            SetState(persister, state, CreateUser, entity.CreateUser);
            entity.CreateDate = DateTime.UtcNow;
            SetState(persister, state, CreateDate, entity.CreateDate);            
        }
        private void SetChange(IStampedEntity entity, object[] state, IEntityPersister persister)
        {
            entity.LastUpdateUser = GetUserName();
            SetState(persister, state, LastUpdateUser, entity.LastUpdateUser);
            entity.LastUpdateDate = DateTime.UtcNow;
            SetState(persister, state, LastUpdateDate, entity.LastUpdateDate);
        }
        private void SetState(IEntityPersister persister, IList<object> state, String propertyName, object value)
        {
            var index = GetIndex(persister, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }
        private Int32 GetIndex(IEntityPersister persister, String propertyName)
        {
            return Array.IndexOf(persister.PropertyNames, propertyName);
        }
        private String GetUserName()
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.User.Identity.Name;
            var windowsIdentity = WindowsIdentity.GetCurrent();
            return windowsIdentity != null ? windowsIdentity.Name : String.Empty;
        }
    }
