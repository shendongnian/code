    class BaseCommand<T> : ICommand<T> {
      public void FindAndExecuteHandler(IKernel kernel) {
        kernel.Resolve<IHandler<T>>().Handle(this);
      }
    }
    
    class Command1 : BaseCommand<Command1> { }
    
    cmd1.FindAndExecuteHandler(container);
