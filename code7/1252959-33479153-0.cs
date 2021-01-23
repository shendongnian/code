    class Program
        {
            static void Main(string[] args)
            {
                var ws = new ServiceReference1.ConsumerSoapClient();
                string result = ws.HelloWorld();
            }
        }
