    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Autofac;
    
    public interface ICommand { }
    public class CommandOne : ICommand { }
    public class CommandTwo : ICommand { }
    
    public interface ICommandHandler<T> where T : ICommand
    {
      void Handle(T arg);
    }
    
    public class CommandOneHandler : ICommandHandler<CommandOne>
    {
      public void Handle(CommandOne arg) { }
    }
    
    public class CommandTwoHandler : ICommandHandler<CommandTwo>
    {
      public void Handle(CommandTwo arg) { }
    }
    
    public interface ICommandBus
    {
      IEnumerable<object> Handlers { get; }
      void RegisterHandler<TCommand, THandler>(THandler handler)
        where THandler : ICommandHandler<TCommand>
        where TCommand : ICommand;
    }
    
    public class CommandBus : ICommandBus
    {
      private readonly List<object> _handlers = new List<object>();
    
      public IEnumerable<object> Handlers
      {
        get
        {
          return this._handlers;
        }
      }
    
      public void RegisterHandler<TCommand, THandler>(THandler handler)
        where THandler : ICommandHandler<TCommand>
        where TCommand : ICommand
      {
        this._handlers.Add(handler);
      }
    }
    
    var builder = new ContainerBuilder();
    
    // Track the list of registered command types.
    var registeredHandlerTypes = new List<Type>();
    builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
      .AsClosedTypesOf(typeof(ICommandHandler<>))
      .OnRegistered(e => registeredHandlerTypes.Add(e.ComponentRegistration.Activator.LimitType));
    
    // Initialize the bus by registering handlers on activating.
    builder.RegisterType<CommandBus>()
      .As<ICommandBus>()
      .OnActivating(e => {
        foreach(var handlerType in registeredHandlerTypes)
        {
          // Due to the generic method, some crazy reflection happens.
          // First, get ICommandHandler<T> interface.
          var handlerInterfaceType = handlerType.GetInterface("ICommandHandler`1");
          // Grab the <T> from the ICommandHandler<T>.
          var commandType = handlerInterfaceType.GetGenericArguments()[0];
          // Build the closed generic version of RegisterHandler<TCommand, THandler>.
          var registerMethod = typeof(ICommandBus).GetMethod("RegisterHandler").MakeGenericMethod(commandType, handlerType);
          // Call the closed generic RegisterHandler<TCommand, THandler> to register the handler.
          registerMethod.Invoke(e.Instance, new object[] { e.Context.Resolve(handlerInterfaceType) });
        }
      })
      .SingleInstance();
    
    var container = builder.Build();
    using(var scope = container.BeginLifetimeScope())
    {
      var bus = container.Resolve<ICommandBus>();
      foreach(var t in bus.Handlers)
      {
        // List the handler types registered.
        Console.WriteLine(t.GetType());
      }
    }
