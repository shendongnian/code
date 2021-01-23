        builder.RegisterType<DbPublisher>().Named<IPublisher>("DB");
        builder.RegisterType<RestPublisher>().Named<IPublisher>("REST");
        builder.Register(c => {
              var index = c.Resolve<IIndex<String, IPublisher>>(); 
              return index[Defs.AppSettings.PublisherType]
        }.As<IPublisher>(); 
