     static void Main(string[] args)
        {
            Bar bar = new Bar();
            Foo foo = (Foo)bar.GetType().GetField("a", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(bar);
            foo.GetType().GetMethod("ShowMessage").Invoke(foo,new object[] { });
        }
        public class Bar
        {
            private Foo a;
            public Bar()
            {
                a = new Foo();
            }
        }
        public class Foo
        {
            public void ShowMessage()
            {
                Console.WriteLine("Hello World!");
            }
        }
