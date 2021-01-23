    public IContainer Bootstrap()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
      builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();
      builder.RegisterType<FileDataService>().As<IDataService>();
      builder.RegisterType<fLookupProvider>().As<ILookupProvider<f>>();
      builder.RegisterType<fGroupLookupProvider>().As<ILookupProvider<fGroup>>();
      builder.RegisterType<fDataProvider>().As<IfDataProvider>();
      builder.RegisterType<fEditViewModel>().As<IfEditViewModel>();
      builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
      builder.RegisterType<MainViewModel>().AsSelf();
      return builder.Build();
    }
  }
