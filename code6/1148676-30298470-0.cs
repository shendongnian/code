    public class Scheduler : IScheduler
    {
    private readonly Quartz.IScheduler quartzScheduler;
    
    private IUnityContainer container;
    
    public Scheduler(IUnityContainer container)
    {
      this.container = container;
      ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
      quartzScheduler = schedulerFactory.GetScheduler();
      quartzScheduler.Start();
    }
    
    public void Stop()
    {
      quartzScheduler.Shutdown(false);
    }
    
    public void ScheduleRoboJob()
    {
      // your code here
      quartzScheduler.ScheduleJob(job, trigger);
    }
