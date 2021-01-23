    class Character
    {
        public delegate void OverlappingHandler(Character character, EventArgs e);
        public event OverlappingHandler OverlappingEvent;
        public void IsOverlapping()
        {
            bool overlapping = true;
            if (overlapping)
            {
                if (OverlappingEvent != null)
                {
                    OverlappingEvent(this, null);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Character c = new Character();
            c.OverlappingEvent += OverlappingEventHandler;
            c.OverlappingEvent += OverlappingSecondEventHandler;
            c.IsOverlapping();
            Console.Read();
        }
        static void OverlappingEventHandler(Character character, EventArgs e)
        {
            Console.WriteLine("We have overlapping here!!");
        }
        static void OverlappingSecondEventHandler(Character character, EventArgs e)
        {
            Console.WriteLine("Seriously, we have overlapping !!");
        }
    }
