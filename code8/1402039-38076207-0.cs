    public interface ICustomSchedulerFactory
	{
		Scheduler Create();
	}
    public class CustomSchedulerFactory: ICustomSchedulerFactory
	{
		private readonly IContainer _container;
		public CustomSchedulerFactory(IContainer container)
		{
			_container = container;
		}
		public Scheduler Create()
		{
			var scheduler = _container.GetInstance<ISchedulerFactory>().GetScheduler();
            scheduler.JobFactory = _container.GetInstance<IJobFactory>();
            return scheduler;
		}
	}
