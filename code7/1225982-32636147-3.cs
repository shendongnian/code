    public class Essentials
    {
        private void DoSomething()
        {
            //doing base stuff...
        }
        public class NetworkEssentials : Essentials
        {
            public void DoNetworkSomething()
            {
                //doing something
                base.DoSomething(); //Perfectly OK
            }
        }
    }
    public class SomeClass : Essentials.NetworkEssentials
    {
        public void DoSomeSomething()
        {
           base.DoSomething(); //Compile time error
        }
    }
