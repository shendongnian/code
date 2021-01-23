    public class Bug
    {
        public string this[string x] => "";
        public string Foo
        {
            get { return this[nameof(Foo)]; } // Warning here
        }
    }
