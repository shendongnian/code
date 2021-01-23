    if `Defs.AppSettings.PublisherType` is defined during registration process, you can simply conditionally register your dependency : 
        switch(Defs.AppSettings.PublisherType){
            case "DB":
                builder.RegisterType<DbPublisher>().As<IPublisher>();
                break; 
            case "REST":
                builder.RegisterType<RestPublisher>().As<IPublisher>(); 
                break; 
            default:
                throw new NotSupportedException(); 
        }
