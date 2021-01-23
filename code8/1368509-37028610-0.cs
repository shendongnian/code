    builder.RegisterType(typeof(RunHistoryRepository))
           .Named<IRunHistoryRepository>("standard");
    builder.RegisterType(typeof(DifferentRunHistoryRepository))
           .Named<IRunHistoryRepository>("different");
    builder.Register(c => {
       if(UserIsInThisRole()) {
           return c.ResolveNamed<IRunHistoryRepository>("different"); 
       } else {
           return c.ResolveNamed<IRunHistoryRepository>("standard"); 
       }
    })
    .As<IRunHistoryRepository>(); 
