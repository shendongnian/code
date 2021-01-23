                FreshIOC.Container.Register<IFormsDevice, DeviceWrapper>();
                FreshIOC.Container.Register<IBluetoothQuery, BluetoothQuery>();
                FreshIOC.Container.Register<ISuperConnectionManager, SuperConnectionManager>();
                FreshIOC.Container.Register<DeviceConnectionTracker>().AsSingleton();
                FreshIOC.Container.Register<MasterParameterContainer>().AsSingleton();
                FreshIOC.Container.Register<ParsingEngine>().AsSingleton();
                var connectionEngine = FreshIOC.Container.Resolve<ConnectionEngine>(
                    new NamedParameterOverloads() { { "poller", new BackgroundWorkerPoll(1000) } });
                FreshIOC.Container.Register<ConnectionEngine>(connectionEngine); // register it for FreshMVVM
