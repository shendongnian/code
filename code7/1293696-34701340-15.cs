    public class WaitForDelegate
    {
        public WaitForDelegate(Action trigger)
        {
            trigger += () => { Console.WriteLine("trigger"); };
        }
    }
