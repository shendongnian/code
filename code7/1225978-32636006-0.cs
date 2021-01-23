    public class Essentials
    {
        public void DoSomething() 
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
        protected new void DoSomething() 
        {
             
        }
    }
    public class someClass : NetworkEssentials
    {
        public void DoSomeSomething()
        {
            base.DoSomething(); //This will go thru NetworkEssentials and not directly to Dosomething
        }
    }
