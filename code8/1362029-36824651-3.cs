        builder.RegisterType<DbPublisher>().AsSelf();
        builder.RegisterType<RestPublisher>().AsSelf();
        builder.Register(c => { 
            switch(Defs.AppSettings.PublisherType){
                case "DB":
                    c.Resolve<DbPublisher>(); 
                    break; 
                case "REST":
                    c.Resolve<RestPublisher>(); 
                    break; 
                default:
                    throw new NotSupportedException(); 
            }
        }).As<IPublisher>(); 
