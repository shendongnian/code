    public interface ICommand
    {
        public Action<string> Execute { get; }
    }
    public class ConnectionCommand : ICommand
    {
        private static void MyExecuteMethod(string ConnectionString)
        {
            ...do some stuff here...;
        }
        public Action<string> Execute { get { return MyExecuteMethod; } }
    }
