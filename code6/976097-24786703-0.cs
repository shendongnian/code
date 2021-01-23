    public class Derived : ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            //example
            int x = 1;
            //call the base OnStart with the arguments
            base.OnStart(args);
        }
    }
