    public class Essentials 
    {
        public virtual void DoSomething() 
        {
             //do what needs to be done at this level
        }
    }
    public class NetworkEssentials : Essentials 
    {
        public override void DoSomething()
        {
            //do what needs to be done at this level
            base.DoSomething(); //launch what needs to be done at Essentials' level.
        }
    }
    public class someClass : NetworkEssentials
    {
        public override DoSomething()
        {
            //do what needs to be done at this level
            base.DoSomething(); //launch what needs to be done at NetworkEssentials' level.
        }
    }
