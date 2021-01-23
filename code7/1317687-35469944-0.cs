    namespace YourNamespace
    {
        using System.Threading;
        public class MainClass
        {
            public void Main()
            {
                PostponedAction action = new PostponedAction();
                action.WaitExecute(DateTime.Today.AddHours(14.5) - DateTime.Now);
            }
        }
        public class PostponedAction
        {
            public void WaitExecute(TimeSpan waitTime)
            {
                Thread.Sleep(waitTime);
                // Do stuff
            }
        }
    }
