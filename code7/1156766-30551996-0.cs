    const string id = "whateverYourIdIs";
    var existing = ScheduledActionService.Find(id);
    if(existing != null)
       ScheduledActionService.Remove(id);
    Alarm alarm = new Alarm(id)
    {
       BeginTime = DateTime.Now.AddSeconds(1),
       Content = "You have reached your location!",
    };
    ScheduledActionService.Add(alarm);
