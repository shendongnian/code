    public class PermissionsRequestBroker {
       public PermissionsRequestWrapper Test() {
          return new PermissionsRequestWrapper( new PermissionsRequest() );
       }
    }
    internal class PermissionsRequest {
       internal PermissionsRequest() {
       }
    }
    // Use 'sealed' to prevent others from inheriting from this class
    public sealed class PermissionsRequestWrapper {
       private PermissionsRequest _permissionsRequest;
       internal PermissionsRequestWrapper(PermissionsRequest permissionsRequest) {
          _permissionsRequest = permissionsRequest;
       }
       /* etc... */
    }
