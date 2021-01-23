    using System.Windows.Threading;
    DispatcherTimer t = new DispatcherTimer();
    t.Interval = new TimeSpan(0, 0, 15); // hours, minutes, seconds (there are more constructors)
    t.Tick += Timer_Tick;
    t.Start();
