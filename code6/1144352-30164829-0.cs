    using System;
    public class Foo
    {
        public void Bar()
        {
            // Compilation error!
            // You need new System.Collections.Generic.List<int>();
            new Collections.Generic.List<int>();
        }
    }
