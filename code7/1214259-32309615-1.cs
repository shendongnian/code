    public Command1 : ICommandHandler<X> {
         private readonly IServiceDispatcher serviceDispatcher;
         public Command1(IServiceDispatcher serviceDispatcher) {
              this.serviceDispatcher = serviceDispatcher;
         }  
         public void Handle(X command) { 
              //do something
              this.serviceDispatcher.DoWork(command.Service);
              //do something else 
         }
    }
