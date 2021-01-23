    public class InheritedMessage : Message {
        //... 
    }
    public class Recipient {
        public Recipient() {
            //Inherited messages are not processed with this subscription 
            Messenger.Default.Register<Message>(
                recipient: this, 
                action: OnMessage);
            //Inherited messages are processed with this subscription 
            Messenger.Default.Register<Message>(
                recipient: this, 
                receiveInheritedMessagesToo: true,
                action: OnMessage);
        }
        void SendMessages() {
            Messenger.Default.Send(new Message());
            Messenger.Default.Send(new InheritedMessage());
        }
        void OnMessage(Message message) {
            //... 
        }
    }
