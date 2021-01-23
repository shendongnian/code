    public class Helper : IHelper
    {
        public bool DoSomething<T>(IFoo<T> model, string path) where T : IBar
        {
            //..Save model to path
            return true;
        }
    }
