    Host host = HostFactory.New(x =>
                {
                    x.Service<IQuartzServer>(s =>
                    {
                        s.SetServiceName("Services");
                        s.ConstructUsing(builder =>
                                                {
                                                    IQuartzServer server = QuartzServerFactory.CreateServer();
                                                    server.Initialize();
                                                    return server;
                                                });
                        s.WhenStarted(server => server.Start());
                        s.WhenPaused(server => server.Pause());
                        s.WhenContinued(server => server.Resume());
                        s.WhenStopped(server => server.Stop());
                    });
    
                    x.RunAsLocalSystem();
    
                    x.SetDescription(Configuration.ServiceDescription);
                    x.SetDisplayName(Configuration.ServiceDisplayName);
                    x.SetServiceName(Configuration.ServiceName);
                });
    
                host.Run();
