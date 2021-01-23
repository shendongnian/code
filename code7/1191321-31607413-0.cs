    public static void Main()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<ShuffleProducts>().Build();
            
            //On Particular Time of day
            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                     s.WithIntervalInHours(24)
                    .OnEveryDay()
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(23,00))
                  )
                .Build();         
           
            scheduler.ScheduleJob(job, trigger);
        }
 
    public class ShuffleProducts : IJob
        {        
            public void Shuufle(IJobExecutionContext context)
            {
               //Shuffle products here... 
            }
        }
