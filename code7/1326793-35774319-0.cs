    // This class provides callbacks to the host app domain.
    // As it is derived from MarshalByRefObject, it will be a remote object
    // when passed to the children.
    // if children are not allowed to reference the host, create an IHost interface
    public class DomainHost : MarshalByRefObject
    {
        // send a message to the host
        public void SendMessage(IChild sender, string message)
        {
            Console.WriteLine($"Message from child {sender.Name}: {message}");
        }
        // sends any object to the host. The object must be serializable
        public void SendObject(IChild sender, object package)
        {
            Console.WriteLine($"Package from child {sender.Name}: {package}");
        }
        // there is no timeout for host
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
