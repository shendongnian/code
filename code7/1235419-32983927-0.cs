    namespace multilistener
    {
        class Program
        {
            static void Main(string[] args)
            {
                string env = "DEV";
                string queueName1= "SUB.Q";
                string queueName2 = "SUB.Q1";
            new MyListener(CallbackHandler1.onMessage1, env, queueName1).RegisterListener();
            new MyListener(CallbackHandler2.onMessage2, env, queueName2).RegisterListener();
            System.Threading.Thread.Sleep(30000);
            Console.WriteLine("Program ends");
         }
    }
    public class MyListener
    {
        public delegate void Handler (IMessage msg);
        public Handler _handler; // Remove 'static' keyword
        private string env = "";
        private string queue = "";
        public MyListener(Handler _Inhandler, string environment, string queueName)
        {
            _handler = _Inhandler;
            this.env = environment;
            this.queue = queueName;
        }
        public void RegisterListener()
        {
            try
            {
                XMSFactoryFactory xff = XMSFactoryFactory.GetInstance(XMSC.CT_WMQ);
                IConnectionFactory cf = xff.CreateConnectionFactory();
                cf.SetStringProperty(XMSC.WMQ_HOST_NAME, "localhost");
                cf.SetIntProperty(XMSC.WMQ_PORT, 1414);
                cf.SetStringProperty(XMSC.WMQ_CHANNEL, "MY.SVRCONN");
                cf.SetIntProperty(XMSC.WMQ_CONNECTION_MODE, XMSC.WMQ_CM_CLIENT);
                cf.SetStringProperty(XMSC.USERID, "userid");
                cf.SetStringProperty(XMSC.PASSWORD, "password");
                cf.SetStringProperty(XMSC.WMQ_QUEUE_MANAGER, "QM1");
                IConnection conn = cf.CreateConnection();
                Console.WriteLine("connection created");
                ISession sess = conn.CreateSession(false, AcknowledgeMode.AutoAcknowledge);
                IDestination dest = sess.CreateQueue(queue);
                IMessageConsumer consumer = sess.CreateConsumer(dest);
                MessageListener ml = new MessageListener(onMessage);
                consumer.MessageListener = ml;
                conn.Start();
                Console.WriteLine("Consumer started");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void onMessage(IMessage m)
        {
            try {
                _handler(m);
            }
            catch (Exception e ) 
            {
                Console.Write(e);
            }
        }
    }
    //callback 1
    public class CallbackHandler1
    {
        public static void onMessage1(IMessage msg)
        {
            ITextMessage textMessage = (ITextMessage)msg;
            // code to perform onmessage1
            Console.WriteLine("First consumer");
        }
    }
  
    //callback 2
    public class CallbackHandler2
    {
        public static void onMessage2(IMessage msg)
        {
            ITextMessage textMessage = (ITextMessage)msg;
            // code to perform onmessage2
            Console.WriteLine("Second consumer");
        }
    }
}
