    public class Receiver
    {
        public Receiver()
        {
            Messenger.Default.Register<NotificationMessage>(this, message =>
                {
                    if ((Type)message.Target == typeof(Receiver))
                        GotRequest(message.Notification);
                }); 
        }
        public void SendResponse(string response)
        {
            Messenger.Default.Send(new NotificationMessage(this, typeof(Sender), response));
        }
        public void GotRequest(string request)
        {
            string response = !string.IsNullOrWhiteSpace(request) ? 
                              "ok" : 
                              JsonConvert.SerializeObject(new NotImplementedException("I haz error!"));
            SendResponse(response);
        }
    }
