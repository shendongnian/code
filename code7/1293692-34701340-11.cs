    public class WaitForDelegate
    {
        public WaitForDelegate(IObservable<Unit> trigger)
        {
            trigger.Subscribe(_ => { Console.WriteLine("trigger"); });
        }
    }
