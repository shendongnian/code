    public class AWNFileGeneratorTask : DDPSchedulerTask
    {
        private IDirectoryResolver _directoryResolver;
        public AWNFileGeneratorTask(ITaskFactory tasksFactory, IDirectoryResolver directoryResolver)
            : base(tasksFactory)
        {
            _directoryResolver = directoryResolver;
        }
    }
