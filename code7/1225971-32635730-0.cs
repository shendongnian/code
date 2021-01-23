    public class Essentials
    {
        protected void DoSomething()
        {
            //doing base stuff...
        }
    }
    public class NetworkEssentials : Essentials
    {
        public void DoNetworkSomething()
        {
            //doing something
        }
        private new void DoSomething()
        {
        }
    }
    public class someClass : NetworkEssentials
    {
        public void DoSomeSomething()
        {
            base.DoSomething(); //The thing I would like to prevent
        }
    }
