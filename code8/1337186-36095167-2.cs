    // Interceptor setting up audit properties.
    [Serializable]
    public class AuditInterceptor : NHibernate.EmptyInterceptor
    {
        public YourAppUser AppUser { get; set; }
        public override bool OnFlushDirty(object entity,
            object id,
            object[] currentState,
            object[] previousState,
            string[] propertyNames,
            NHibernate.Type.IType[] types)
        {
            var modified = false;
            for (int i = 0; i < propertyNames.Length; i++)
            {
                switch (propertyNames[i])
                {
                    case "UpdateDate":
                        currentState[i] = DateTimeOffset.Now;
                        modified = true;
                        break;
                    case "Updater":
                        currentState[i] = AppUser;
                        modified = true;
                        break;
                }
            }
            return modified;
        }
        public override bool OnSave(object entity,
            object id,
            object[] state,
            string[] propertyNames,
            NHibernate.Type.IType[] types)
        {
            var modified = false;
            for (int i = 0; i < propertyNames.Length; i++)
            {
                switch (propertyNames[i])
                {
                    case "CreationDate":
                        state[i] = DateTimeOffset.Now;
                        modified = true;
                        break;
                    case "Creator":
                        state[i] = AppUser;
                        modified = true;
                        break;
                }
            }
            return modified;
        }
    }
