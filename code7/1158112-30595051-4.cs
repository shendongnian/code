    public class SomeClass
    {
        public static CreateCommand(SomeType state, SomeEventHandler eventHandler)
        {
            eventHandler += (s, e) => MyDelegate(state, s, e);
        }
        private static void MyDelegate(SomeType state, object sender, EventArgs e)
        {
            // do something with state, when the event is fired.
        }
    }
