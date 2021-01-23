    public class PermissionsRequest
    {
        private PermissionsRequest()
        { }
        public sealed class Broker
        {
            public static PermissionsRequest CreatePermissionsRequest()
            {
                return new PermissionsRequest();
            }
            public PermissionsRequest CreatePermissionsRequest_Instance()
            {
                return new PermissionsRequest();
            }
        }
    }
    public class UserClass
    {
        public void Blah()
        {
            var permissionsRequest = PermissionsRequest.Broker.CreatePermissionsRequest();
            var broker = new PermissionsRequest.Broker();
            var permRequest = broker.CreatePermissionsRequest_Instance();
        }
    }
