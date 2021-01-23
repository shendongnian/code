    public class AuditHandler : IAuditHandler {
        public void AuditInformation(string preAuditValues) {
            var audit = new Audit();
            audit.preAuditValues = preAuditValues;
            audit.AuditInformation();
        }
    }
