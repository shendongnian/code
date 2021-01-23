    public class WaitForDelegate<T> where T : IAnimation
    {
        public WaitForDelegate(T animation)
        {
            animation.OnEnd += () => { Console.WriteLine("trigger"); };
        }
    }
