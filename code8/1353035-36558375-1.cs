    partial class Foo
    {
        partial void Bar();  // no implementation
        public void DoSomething()
        {
            // do some stuff...
            Bar();    // this will be removed if Bar isn't implemented in another partial class
            // do something else...
        }
    }
