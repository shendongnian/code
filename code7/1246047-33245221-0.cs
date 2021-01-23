    public interface IChannel
    {
        void DoSomething();
        string DoSomethingElse();
    }
    
    public class SipChannel : IChannel
    {
        public void DoSomething()
        {
            //go do some stuff
        }
    
        public string DoSomethingElse()
        {
            return "I did some stuff for you.";
        }
    }
    
    public OtherChannel : IChannel
    {
        public void DoSomething()
        {
            //go do some stuff
        }
    
        public string DoSomethingElse()
        {
            return "I'm not sure what this one does yet.";
        }
    }
