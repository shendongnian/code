    class EventSender
    {
        public Action MyEvent;
    }
    
    class Subscriber
    {
        public void OnEvent()
        {
            Console.WriteLine("OnEvent");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            EventSender es = new EventSender();
    
            Subscriber s = new Subscriber();
            es.MyEvent += s.OnEvent;
    
            s = new Subscriber();
            es.MyEvent += s.OnEvent;
    
            es.MyEvent();
    
            Console.ReadKey();
        }
    }
