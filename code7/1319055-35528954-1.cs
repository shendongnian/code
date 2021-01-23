    public class Connector : IConnector
    {
        public Connector(Func<Action, ITaskWrapper> taskWrapperFactory)
        {
            var taskWrapper = taskWrapperFactory(Connect);
        }
        private void Connect()
        {            
        }
    }
    public class TaskWrapper : ITaskWrapper
    {
        private readonly Action _task;
        public TaskWrapper(Action task)
        {
            _task = task;
        }
    }
