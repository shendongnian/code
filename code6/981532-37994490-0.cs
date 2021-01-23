    namespace TrickAddEventHandlerInObjectInitializer
    {
    class A
    {
        public EventHandler AddHandlerToEventByAssignMe
        {
            set { Event += value; }
        }
        public event EventHandler Event;
        public void DoSmthAndInvoke()
        {
            Event?.Invoke(this, new EventArgs());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A
            {
                AddHandlerToEventByAssignMe = A_Event
            };
            a.DoSmthAndInvoke();
        }
        private static void A_Event(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    }
