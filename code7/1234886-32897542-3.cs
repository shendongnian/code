    HostFactory.Run(x =>
        {
            x.EnableStartParameters();
            x.UseNLog();
            x.Service<MyService>(sc =>
            {
                sc.ConstructUsing(hs => new MyService(hs));
                sc.WhenStarted((s, h) => s.Start(h));
                sc.WhenStopped((s, h) => s.Stop(h));
            });
            x.WithStartParameter("config",a =>{/*we can use parameter here*/});
            x.SetServiceName("MyService");
            x.SetDisplayName("My Service");
            x.SetDescription("My Service Sample");
            x.StartAutomatically();
            x.RunAsLocalSystem();
            x.EnableServiceRecovery(r =>
            {
                r.OnCrashOnly();
                r.RestartService(1); //first
                r.RestartService(1); //second
                r.RestartService(1); //subsequents
                r.SetResetPeriod(0);
            });
        });
