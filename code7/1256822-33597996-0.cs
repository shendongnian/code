    class NetClient
    {
        public string Host { get; }
        public int Port { get; }
        public NetClient(string host, int port)
        {
            this.Host = host;
            this.Port = port;
        } 
        public Headers CreateObjHeaders(string Name, string Value)
        { 
            Headers objHeaders=new Headers("Name", "Value");
            return objHeaders;
        }
        public class Headers
        {
           public Headers(string Name, string Value)
           { 
               Header objHeader=new Header("Name", "Value"); 
           }
           public class Header
           {
                public string Name { get; }
                public string Value { get; }
             
                internal Header(string name, string value)
                {
                     this.Name = name;
                     this.Value = value;
                }
           }
