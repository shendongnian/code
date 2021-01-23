    public CommandHandler1 : ICommandHandler<CommandParameter1> {
         private readonly IServiceDispatcher serviceDispatcher;
         public CommandHandler1(IServiceDispatcher serviceDispatcher) {
              this.serviceDispatcher = serviceDispatcher;
         }  
         public void Handle(CommandParameter1 commandParameter) { 
              //do something
              this.serviceDispatcher.DoWork(commandParameter.Service);
              //do something else 
         }
    }
