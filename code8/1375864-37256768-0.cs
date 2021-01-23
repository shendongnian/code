    public class Message {
        //... 
    }
    public class Recipient {
        public Recipient() {
            Messenger.Default.Register<string>(this, OnMessage1);
            Messenger.Default.Register<Message>(this, OnMessage2);
        }
        void SendMessages() {
            Messenger.Default.Send("test");
            Messenger.Default.Send(new Message());
        }
        void OnMessage1(string message) {
            //... 
        }
        void OnMessage2(Message message) {
            //... 
        }
    } 
