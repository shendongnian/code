    // this gets instantiated by clients over remoting
    public class Server:MarshalByRefObject
    {
        // server wide state
        public static int Value;
    
        // state only for this instance (that can be shared with several clients
        // depending on its activation model)
        private StringBuilder buildup;
    
        // an instance
        public Server()
        {
            buildup = new StringBuilder();
            Console.WriteLine("server started");
        }
    
        // do something useful
        public int DoWork(char ch)
        {
            Console.WriteLine("server received {0}", ch);
            buildup.Append(ch);
            return Value;
        }
    
        // return all typed chars
        public string GetMessage()
        {
            Console.WriteLine("server GetMessage called") ;
            return buildup.ToString();
        }
    
        // how long should this instance live
        public override object InitializeLifetimeService()
        {
            // run forever
            return null;
        }
    }
