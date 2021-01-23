    public class SimpleChatCallback : IChatServiceCallback
    {
        public void Receive(Person sender, string message)
        {
            Console.WriteLine("Receive: {0} {1}", sender.Name, message);
        }
        public void ReceiveWhisper(Person sender, string message)
        {
            Console.WriteLine("ReceiveWhisper: {0} {1}", sender.Name, message);
        }
        public void UserEnter(Person person)
        {
            Console.WriteLine("UserEnter: {0}", person.Name);
        }
        public void UserLeave(Person person)
        {
            Console.WriteLine("UserLeave: {0}", person.Name);
        }
    }
