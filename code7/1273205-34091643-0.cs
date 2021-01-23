            FreshIOC.Container.Register<ConnectionEngine>().UsingConstructor(() => 
            new ConnectionEngine(
                FreshIOC.Container.Resolve<ISuperConnectionManager>() as ISuperConnectionManager,
                FreshIOC.Container.Resolve<IBluetoothQuery>() as IBluetoothQuery,
                new BackgroundWorkerPoll(1000), 
                FreshIOC.Container.Resolve<IFormsDevice>() as IFormsDevice));
