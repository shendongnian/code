    public class DomainBase<T>
    {
        public DomainBase(bool isAuditEnabled)
        {
            this.IsAuditEnabled = isAuditEnabled;
        }
        public bool IsAuditEnabled { get; set; }
        public void AddNew(T newEntity)
        {
            // default code for adding an entity
            this.Audit_Create(newEntity);
        }
        public void Audit_Create(T newEntity)
        {
            if (IsAuditEnabled)
            {
                // ...
            }
        }
    }
