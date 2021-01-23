    public class MultiUseDependencies
    {
        private readonly IAuditHandler _auditHandler;
        public MultiUseDependencies(IAuditHandler auditHandler) {
            _auditHandler = auditHandler;
        }
        public void Update() {
            this.Delete();
            _auditHandler.AuditInformation("Update");
        }
        public void Delete() {
            // Delete data, implementation omitted.
            _auditHandler.AuditInformation("Delete");
        }
    }
