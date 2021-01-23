    public class SomeClass
    {
        public static CreateCommand(SomeType state, SomeEventHandler eventHandler)
        {
            someEventHandler += (s, e) => MyDelegate(state, s, e);
        }
        private static void MyDelegate(SomeType state, object sender, EventArgs e)
        {
            // do something with state
        }
    }
