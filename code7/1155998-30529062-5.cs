    public interface ITaskFactory
    {
        DDPSchedulerTask CreateDDPSchedulerTask();
        AWNFileGeneratorTask CreateAWNFileGeneratorTask(string extraParam);
    }
    public class AWNFileGeneratorTask : DDPSchedulerTask
    {
        private IDirectoryResolver _directoryResolver;
        private string _extraParam;
        public AWNFileGeneratorTask(ITaskFactory tasksFactory, IDirectoryResolver directoryResolver,
            string extraParam)
            : base(tasksFactory)
        {
            _extraParam = extraParam;
            _directoryResolver = directoryResolver;
        }
    }
    public void CreateAwnFileTask()
    {
        var task = _tasksFactory.CreateAWNFileGeneratorTask("extra");
        _tasksList.Add(task);
    }
