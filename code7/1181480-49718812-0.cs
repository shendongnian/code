    [ProtoContract]
    public class MyClass
    {
        [ProtoMember(1, OverwriteList = true)]
        private List<Foo> MutableFoos { get; set; }
        public IReadOnlyList<IFoo> Foos
        {
            get { return MutableFoos; }
        }
    }
