    public class Essentials 
    {
        virtual public void DoSomething() 
        {
             //doing base stuff...
        }
    }
    
    public class NetworkEssentials : Essentials 
    {
        override public void DoSomething() 
        {
           base.DoSomething();
           // and other struff
        }
        public void DoNetworkSomething()
        {
            //doing something
        }
    }
    
    public class someClass : NetworkEssentials
    {
        public void DoSomeSomething()
        {
            // can ONLY call nearest parent's that implements DoSomething 
            // so next calls NetworkEssentials.DoSomething 
            base.DoSomething(); 
        }
    }
