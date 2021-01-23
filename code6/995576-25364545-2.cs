    TaskScheduler.UnobservedTaskException += (o, ev) =>
    {
        Console.WriteLine(ev.Exception); 
        Console.WriteLine("---------");
        ev.SetObserved();
    };
