        public static void init() {
            EventInfo eventInfo = typeof(Cat).GetEvent("myEvent",
                BindingFlags.NonPublic | BindingFlags.Static);
            MethodInfo adder = typeof(Cat).GetMethod("add_myEvent",
                BindingFlags.NonPublic | BindingFlags.Static);
            MethodInfo target = typeof(Dog).GetMethod("newMethod", 
                BindingFlags.NonPublic | BindingFlags.Static);
            Delegate handler =  Delegate.CreateDelegate(eventInfo.EventHandlerType, target);
            adder.Invoke(null, new object[] { handler });
        }
