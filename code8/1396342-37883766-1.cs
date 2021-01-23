    eventAggregator = new EventAggregator();
    var type = typeof(IMyInterface);
    var types = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => type.IsAssignableFrom(p));
    
    foreach (var t in types)
    {
        var instance = (IMyInteface)Activator.CreateInstance(t);
        batch.AddExportedValue<IMessageSender>(t.Name, new MessageSender(instance, eventAggregator);
    }
