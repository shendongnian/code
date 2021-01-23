    public class RootEventClass
    {
        public event EventHandler SomeKindOfEvent;
        protected virtual void OnSomeKindOfEvent(object sender, EventArgs e)
        {
            EventHandler handler = SomeKindOfEvent;
            if (handler != null)
                handler(this, e);
        }
        public void RaiseEvent()
        {
            Console.WriteLine("Root Event Firing");
            OnSomeKindOfEvent(this, EventArgs.Empty);
        }
    }
    public class FirstOwnerClass
    {
        private RootEventClass _rootClass;
        public event EventHandler SomeKindOfEvent;
        public FirstOwnerClass()
        {
            _rootClass = new RootEventClass();
            _rootClass.SomeKindOfEvent += _rootClass_SomeKindOfEvent;
        }
        void _rootClass_SomeKindOfEvent(object sender, EventArgs e)
        {
            Console.WriteLine("First Owner Class Handling Root Owner Event");
            OnSomeKindOfEvent(this, e);
        }
        protected virtual void OnSomeKindOfEvent(object sender, EventArgs e)
        {
            EventHandler handler = SomeKindOfEvent;
            if (handler != null)
                handler(this, e);
        }
        public void RaiseEvent()
        {
            _rootClass.RaiseEvent();
        }
    }
    public class SecondOwnerClass
    {
        private FirstOwnerClass _firstClass;
        public event EventHandler SomeKindOfEvent;
        public SecondOwnerClass()
        {
            _firstClass = new FirstOwnerClass();
            _firstClass.SomeKindOfEvent +=_firstClass_SomeKindOfEvent;
        }
        void _firstClass_SomeKindOfEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Second Owner Class Handling First Owner Event");
            OnSomeKindOfEvent(this, e);
        }
        protected virtual void OnSomeKindOfEvent(object sender, EventArgs e)
        {
            EventHandler handler = SomeKindOfEvent;
            if (handler != null)
                handler(this, e);
        }
        public void RaiseEvent()
        {
            _firstClass.RaiseEvent();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            SecondOwnerClass secondOwner = new SecondOwnerClass();
            secondOwner.SomeKindOfEvent += secondOwner_SomeKindOfEvent;
            secondOwner.RaiseEvent();
            Console.ReadKey(true);
        }
        static void secondOwner_SomeKindOfEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Got an event from the second owner defined in main");
        }
    }
