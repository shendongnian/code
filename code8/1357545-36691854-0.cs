    public class Foo : IFoo<Bar>
    {
        public Bar Prop1 { get; set; }
        public static Foo Unset { get { return new Foo(); } }
        public IFoo<Bar> IFoo<Bar>.Unset { get { (IFoo<Bar>) return Foo.Unset } }
    }
