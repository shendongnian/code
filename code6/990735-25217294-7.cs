        public static class FooHelper
        {
            private readonly static Foo allValues = ((Foo[])Enum.GetValues(typeof(Foo))).Aggregate((Foo)0, (all, cur) => all | cur);
            public static Foo AllValues { get { return allValues ; } }
        }
