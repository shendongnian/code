    namespace SimpleCqrs {
      using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Reflection;
      using System.Threading.Tasks;
    
      public interface ICommandMessage {
        Guid Id { get; }
        DateTime DateRequestedUtc { get; }
      }
    
      internal abstract class BaseCommandMessage : ICommandMessage {
        protected BaseCommandMessage() {
          DateRequestedUtc = DateTime.UtcNow;
          Id = Guid.NewGuid();
        }
    
        public DateTime DateRequestedUtc {
          get; private set;
        }
    
        public Guid Id {
          get; private set;
        }
      }
    
      internal class ExampleCommand : BaseCommandMessage {
        public string Message { get; set; }
      }
    
      internal class AnotherExampleCommand : BaseCommandMessage {
        public string Message { get; set; }
      }
    
      internal interface ICommandHandler<in TCommand> where TCommand : class, ICommandMessage
      {
        Task HandleAsync(TCommand command);
      }
    
      internal class WriteService : ICommandHandler<ExampleCommand>, ICommandHandler<AnotherExampleCommand>
      {
        public Task HandleAsync(AnotherExampleCommand command) {
          return Task.Run(() => {
            Console.WriteLine(command.Message);
          });
        }
    
        public Task HandleAsync(ExampleCommand command)
        {
          return Task.Run(() =>
          {
            Console.WriteLine(command.Message);
          });
        }
      }
    
      public interface ICommandBus
      {
       void Dispatch(ICommandMessage command);
      }
    
      public class SimpleCommandBus : ICommandBus
      {
        Dictionary<Type, Type> handlers;
        MethodInfo dispatchCommand;
    
        public SimpleCommandBus()
        {
          this.handlers = RegisterCommandHandlers();
          this.dispatchCommand = GetType().GetMethod("DispatchCommand", BindingFlags.NonPublic | BindingFlags.Instance);
        }
    
        public void Dispatch(ICommandMessage command)
        {
          var cmdType = command.GetType();
          var handler = Activator.CreateInstance(handlers[cmdType]);
          var genericMethod = dispatchCommand.MakeGenericMethod(cmdType);
          genericMethod.Invoke(this, new object[] { handler, command });
        }
    
        async void DispatchCommand<T>(ICommandHandler<T> handler, T command) where T : class, ICommandMessage
        {
          await handler.HandleAsync(command);
        }
    
        Dictionary<Type, Type> RegisterCommandHandlers()
        {
          Func<Type, bool> isCommandHandler = t => 
            t.GetInterfaces()
             .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>));
    
          Func<Type, IEnumerable<Tuple<Type, Type>>> collect = t =>
            t.GetInterfaces().Select(i =>       
              Tuple.Create(i.GetGenericArguments()[0], t));
         
          return Assembly.GetCallingAssembly()
                         .GetTypes()
                         .Where(t => !t.IsAbstract && !t.IsGenericType)
                         .Where(isCommandHandler)
                         .SelectMany(collect)
                         .ToDictionary(x => x.Item1, x => x.Item2);
        }
      }
    
    
      class Program
      {
        static void Main(string[] args)
        {
          var bus = new SimpleCommandBus();
          bus.Dispatch(new ExampleCommand { Message = "Hello" });
          bus.Dispatch(new AnotherExampleCommand { Message = "World" });
          Console.ReadKey();
        }
      }
    }
