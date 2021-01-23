    abstract class Foo
    {
        protected abstract string _ElementName { get; }
        public static string GetElementName<T>() where T : Foo, new()
        {
            return typeof(T).GetProperty("_ElementName", BindingFlags.Instance | BindingFlags.NonPublic)
                            .GetValue(new T()) as string;
        }
        public static string GetStaticElementName<T>() where T : Foo, new()
        {
            return typeof(T).GetProperty("ElementName", BindingFlags.Static | BindingFlags.NonPublic)
                            .GetValue(null) as string;
        }
    }
    class Bar : Foo
    {
        protected static string ElementName
        {
            get
            {
                return "StaticBar";
            }
        }
        protected override string _ElementName
        {
            get
            {
                return "Bar";
            }
        }
    }
    class FooBar : Bar
    {
        protected static string ElementName
        {
            get
            {
                return "StaticFooBar";
            }
        }
        protected override string _ElementName
        {
            get
            {
                return "FooBar";
            }
        }
    }
    class Baz<T> where T : Foo, new()
    {
        public string ElementName
        {
            get
            {
                return Foo.GetElementName<T>();
            }
        }
        public string StaticElementName
        {
            get
            {
                return Foo.GetStaticElementName<T>();
            }
        }
    }
    ...
    Console.WriteLine(new Baz<Bar>().ElementName); // Bar
    Console.WriteLine(new Baz<FooBar>().ElementName); // FooBar
    Console.WriteLine(new Baz<Bar>().StaticElementName); // StaticBar
    Console.WriteLine(new Baz<FooBar>().StaticElementName); // StaticFooBar
