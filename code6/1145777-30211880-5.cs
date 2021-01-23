    public class Sender
    {
        public Sender()
        {
            Messenger.Default.Register<NotificationMessage>(this, message =>
                {
                    if ((Type)message.Target == typeof(Sender))
                       GotResponse(message.Notification);
                });    
        }
        public void SendRequest(string request)
        {
            Console.WriteLine("sending:{0}", request);
            Messenger.Default.Send(
                new NotificationMessage(this, typeof(Receiver), request));
        }
        private void GotResponse(string response)
        {
            Console.WriteLine("received:{0}", response);
            if (response.Equals("ok"))
                return;
            Exception exception = JsonConvert.DeserializeObject<Exception>(response);
            Console.WriteLine("exception:{0}", exception);
            
            try
            {
                throw exception;
            }
            catch (Exception e)
            {
                Console.WriteLine("Indeed, it was {0}", e);
            }
        }
    }
