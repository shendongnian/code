    HostFactory.Run(c =>
                    {
                        c.Service<ContainerService>(s =>
                        {
                            s.ConstructUsing(name => new ContainerService());
                            s.WhenStarted((service, control) => service.Start());
                            s.WhenStopped((service, control) => service.Stop());
        
                            s.ScheduleQuartzJob<ContainerService>(q =>
                                q.WithJob(() =>
                                    JobBuilder.Create<TypeA>().Build())
                                .AddTrigger(() =>
                                    TriggerBuilder.Create()
                                        .WithSimpleSchedule(builder => builder
                                            .WithIntervalInSeconds(20)
                                            .RepeatForever())
                                        .Build())
                                );
        
                            s.ScheduleQuartzJob<ContainerService>(q =>
                                q.WithJob(() =>
                                    JobBuilder.Create<TypeB>().Build())
                                .AddTrigger(() =>
                                    TriggerBuilder.Create()
                                        .WithSimpleSchedule(builder => builder
                                            .WithIntervalInSeconds(60)
                                            .RepeatForever())
                                        .Build())
                                );
                        });
        
                    });
