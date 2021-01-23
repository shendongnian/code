    class Program
    {
        static void Main(string[] args)
        {
            var a = new MyCommandHandler();
            var z = new MyBaseCommandHandler();
            var b = a as ICommandHandler<CommandBase>;
            var y = z as ICommandHandler<CommandBase>;
            var x = z as ICommandHandler<MyCommand>;
        }
    }
    public class MyBase { }
    public abstract class CommandBase : MyBase { }
    public class MyCommand : CommandBase { }
    public interface ICommandHandler { }
    public interface ICommandHandler<in T> : ICommandHandler where T : CommandBase
    {
        IEnumerable<EventBase> Handle(T item);
    }
    public class MyCommandHandler : ICommandHandler<MyCommand>
    {
        public IEnumerable<EventBase> Handle(MyCommand item)
        {
            return new List<EventBase>();
        }
    }
    public class MyBaseCommandHandler : ICommandHandler<CommandBase>
    {
        public IEnumerable<EventBase> Handle(CommandBase item)
        {
            return new List<EventBase>();
        }
    }
    public class EventBase
    { }
