    public abstract class BaseCommand
    {
        public abstract RxObservables Execute();
    }
    public class DBCommand : BaseCommand
    {
        public override RxObservables Execute()
        {
            return new RxObservables();
        }
    }
    public class WebServiceCommand : BaseCommand
    {
        public override RxObservables Execute()
        {
            return new RxObservables();
        }
    }
    public class ReTryCommand : BaseCommand // Decorator to existing db/web command
    {
        private readonly BaseCommand _baseCommand;
        public RetryCommand(BaseCommand baseCommand)
        {
             _baseCommand = baseCommand
        }
        public override RxObservables Execute()
        {
            try
            {
                //retry using Polly or Custom
                return _baseCommand.Execute();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public class TaskDispatcher
    {
        private readonly BaseCommand _baseCommand;
        public TaskDispatcher(BaseCommand baseCommand)
        {
            _baseCommand = baseCommand;
        }
        public RxObservables ExecuteTask()
        {
            return _baseCommand.Execute();
        }
    }
    public class Orchestrator
    {
        public void Orchestrate()
        {
            var taskDispatcherForDb = new TaskDispatcher(new ReTryCommand(new DBCommand));
            var taskDispatcherForWeb = new TaskDispatcher(new ReTryCommand(new WebCommand));
            var dbResultStream = taskDispatcherForDb.ExecuteTask();
            var WebResultStream = taskDispatcherForDb.ExecuteTask();
        }
    }
