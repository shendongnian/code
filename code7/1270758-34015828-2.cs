    public class X
    {
        public X([CallerMemberName] string caller = null)
        {
            this.Caller = caller;
        }
        public string Caller { get; private set; }
    }
