        public class Foo
        {
            public string Name { get; set; }
        }
        public class Bar
        {
            public Foo MyFoo { get; set; }
            public Bar(Foo paramFoo)
            {
                this.MyFoo = paramFoo;
            }
        }
