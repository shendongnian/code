    public class FirstLevel<T> : Base<T> where T:Poco2
    {
        public override void Method(T parameter)
        {
            // Do something general with ExtraData...
            base.Method(parameter);
        }
    }
    public class SecondLevel<T> : FirstLevel<T> where T: Poco3
    {
        public override void Method(T parameter)
        {
            // Do something with EvenMoreData...
            base.Method(parameter);
        }
    }
