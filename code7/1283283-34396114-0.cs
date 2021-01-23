    public class AuditHandler : IAuditHandler {
        void AuditInformation(string preAuditValues) {
            var audit = new Audit();
            audit.preAuditValues = preAuditValues;
            audit.AuditInformation();
        }
    }
