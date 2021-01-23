    public class TestEvent
    {
        public event Action Event;
    
        public TestEvent()
        {
            Action d1 = Print;
            Action d2 = Print;
    
            // The delegates are distinct
            Console.WriteLine("d1 and d2 are the same: {0}", object.ReferenceEquals(d1, d2));
    
            Event += d1;
            Event -= d2;
    
            // But the second one is able to remove the first one :-)
            // (an event when is empty is null)
            Console.WriteLine("d2 was enough to remove d1: {0}", Event == null);
        }
    
        public void Print()
        {
            Console.WriteLine("TestEvent");
        }
    }
