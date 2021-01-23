    namespace ConsoleApplication1
    {
    
        public static class Cat
        {
            internal static event EventHandler myEvent;
    
            public static void RaiseEvent()
            {
                if (myEvent != null) myEvent(typeof(Cat), EventArgs.Empty);
            }
        }
    
    
        class Dog
        {
            public static void init()
            {
                EventInfo eventInfo = typeof(Cat).GetEvent("myEvent", BindingFlags.NonPublic | BindingFlags.Static);
                MethodInfo addInfo = typeof(Cat).GetMethod("add_myEvent", BindingFlags.NonPublic | BindingFlags.Static);
                EventHandler handler = new EventHandler(Handler);
                addInfo.Invoke(null, new object[] { handler });
            }
    
            static void Handler(object sender, EventArgs e)
            {
                Console.WriteLine("Event fired");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Dog.init();
                Cat.RaiseEvent();
            }
        }
    }
