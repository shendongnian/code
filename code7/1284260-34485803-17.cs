    public class SimpleChatCallback : IChatServiceCallback
    {
        public void Receive(Person sender, string message)
        {
            Console.WriteLine("{0}: {1}", sender.Name, message);
        }
        public void ReceiveWhisper(Person sender, string message)
        {
            Console.WriteLine("{0}: {1}", sender.Name, message);
        }
        public void UserEnter(Person person)
        {
            Console.WriteLine("{0} has entered", person.Name);
        }
        public void UserLeave(Person person)
        {
            Console.WriteLine("{0} has left", person.Name);
        }
    }
