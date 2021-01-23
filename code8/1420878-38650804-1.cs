    public class PermissionsRequestBroker {
        public PermissionsRequest Test() {
            return new PermissionsRequest();
        }
    
        public sealed class PermissionsRequest {
            private PermissionsRequest() {
    
            }
        }
    }
