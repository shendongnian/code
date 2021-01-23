    internal class StrDoSomethingCoupler
    {
        private readonly Action _doSomething;
        private string str;
        public StrDoSomethingCoupler(Action doSomething)
        {
            _doSomething = doSomething;
        }
        public string Str
        {
            get { return _str; }
            set { _str = value; _doSomething(); }
        }
    }
    public class SomeClass
    {
        private readonly StrDoSomethingCoupler _coupler =
            new StrDoSomethingCoupler(DoSomething);
        ...
        public string Str
        {
            get { return _couple.Str; }
            set { _coupler.Str = value; }
        }
    }
