    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    
    namespace Application2
    {
        [ServiceContract]
        public interface IEchoService
        {
            [OperationContract]
            string Echo(string value);
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                //In real implementation, use server IP instead of localhost
                ChannelFactory<IEchoService> factory = new ChannelFactory<IEchoService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:8000/Echo"));
                IEchoService proxy = factory.CreateChannel();
                int processedSeccond = 0;
                while (true)
                {
                    var dateTime = DateTime.Now;
                    if (dateTime.Second % 10 == 0 && dateTime.Second!=processedSeccond)
                    {
                        processedSeccond = dateTime.Second;
                        string data= dateTime.ToString(); //or Console readLine for manual data entry
                        Console.WriteLine("Recieved Response: " + proxy.Echo(str));
                    }
                }
            }
        }
    }
