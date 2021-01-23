    container.RegisterType<IDataRepository, DataRepository>("Online");
    container.RegisterType<IDataRepository, OfflineDataRepository>("Offline");
    container.RegisterType<IDataRepository>(new InjectionFactory(c => { 
        var connectivityStatus = /*TODO: logic to determine if online*/
            ? "Online"
            : "Offline";
        return c.Resolve<IDataRepository>(connectivityStatus);            
    });
