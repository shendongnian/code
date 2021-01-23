		 public class Schedule : ISchedule
		{
			readonly List<Timer> timers = new List<Timer>();
			public Schedule()
			{
			}
			public Timer Every(TimeSpan interval, Action action)
			{
				var timer = new Timer(_ => action(), null, new TimeSpan(), interval);
				timers.Add(timer);
				return timer;
			}
			public void Stop(Timer timer)
			{
				if (timer != null && timers.Contains(timer))
				{
					timer.Dispose();
					timers.Remove(timer);
				}
			}
		}
		public class MyMainClass
		{
		   void Main(){
			  var processor = new MyProcessor();	
			  ISchedule scheduler = new Schedule();
			  schedule.Every(TimeSpan.FromDays(1), processor.Run)
		   }
		}
	 
		public class MyProcessor
		{
		   void Run(){
			//do more here
		   }
		 }
