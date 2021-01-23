    using System;
    using System.Collections.Generic;
    using Ninject;
    using Ninject.Extensions.Factory;
    internal class Program
    {
        public static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<DDPSchedulerTask>().ToSelf();
            ninjectKernel.Bind<AWNFileGeneratorTask>().ToSelf();
            ninjectKernel.Bind<IDirectoryResolver>().To<DirectoryResolver>();
            ninjectKernel.Bind<ITaskFactory>().ToFactory();
            var mainTask = ninjectKernel.Get<DDPSchedulerTask>();
            mainTask.CreateDbSchedulerTask();
            mainTask.CreateAwnFileTask();
            Console.ReadLine();
        }
    }
    public interface ITaskFactory
    {
        TTask CreateTask<TTask>() where TTask : DDPSchedulerTask;
    }
    public class DDPSchedulerTask
    {
        private readonly ITaskFactory _tasksFactory;
        private readonly List<DDPSchedulerTask> _tasksList;
        public DDPSchedulerTask(ITaskFactory tasksFactory)
        {
            _tasksFactory = tasksFactory;
            _tasksList = new List<DDPSchedulerTask>();
        }
        public void CreateAwnFileTask()
        {
            var task = _tasksFactory.CreateTask<AWNFileGeneratorTask>();
            _tasksList.Add(task);
        }
        public void CreateDbSchedulerTask()
        {
            var task = _tasksFactory.CreateTask<DDPSchedulerTask>();
            _tasksList.Add(task);
        }
    }
    public class AWNFileGeneratorTask : DDPSchedulerTask
    {
        [Inject]
        public IDirectoryResolver DirectoryResolver { get; set; }
        public AWNFileGeneratorTask(ITaskFactory tasksFactory)
            : base(tasksFactory)
        {
        }
    }
    public interface IDirectoryResolver
    {
    }
    public class DirectoryResolver : IDirectoryResolver
    {
    }
