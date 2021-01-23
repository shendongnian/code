    public class TestClass
    {
        public bool Watch { get; set; }
        public void ParentMethod()
        {
            Func<bool> c1Call = () => { Child1Method(); return Watch; };
            Func<bool> c2Call = () => { ChildMethod2(); return Watch; };
            if (c1Call())
                return;
            if (c2Call())
                return;
        }
        public void Child1Method()
        {
            //Do something, then this happens:
            Watch = true;
        }
        public void ChildMethod2()
        {
            //Do something, then maybe this happens:
            Watch = true;
        }
    }
