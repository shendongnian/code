    public class AlphaArgs
    {
        public AlphaArgs(int a, object b)
        {
            //do stuff
        }
        public int A { get; }
        public object B { get; }
    }
    public class BetaArgs : AlphaArgs
    {
        public BetaArgs(int a, object b, string c) : base(a, b)
        {
            /* Do Stuff */
        }
        public string C { get; }
    }
    public class Alpha<T> where T : AlphaArgs
    {
        protected virtual void OnSpecialEvent(T e)
        {
            //do stuff
        }
    }
    public class Beta : Alpha<BetaArgs>
    {
        protected override void OnSpecialEvent(BetaArgs e)
        {
            //do stuff
        }
    }
