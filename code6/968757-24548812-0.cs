    [Test]
    public void LoopTest()
    {
        var eventManager = new EventManager();
        eventManager.IntroduceEvent("A",typeof(EventArgs));
        eventManager.IntroduceEvent("B", typeof(EventArgs));
    
        eventManager.Subscribe<EventArgs>("A", (sender, args) =>
        {
            Console.WriteLine("Raise B");
            eventManager.RaiseAsync("B", sender, args);
        });
        eventManager.Subscribe<EventArgs>("B", (sender, args) =>
        {
            Console.WriteLine("Raise A");
            eventManager.RaiseAsync("A", sender, args);
        });
    
        eventManager.RaiseAsync<EventArgs>("A",null,null);
    
        //Wait a little bit to get more async events processed
        System.Threading.Thread.Sleep(1000);
    }
