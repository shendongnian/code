    void Main()
    {
    	var schedules = new[]{
    		new Schedule() { IsOn = true, DayOfWeek = DayOfWeek.Monday, TimeFrom = 540, TimeTo = 1080 },
    		new Schedule() { IsOn = false, DayOfWeek = DayOfWeek.Monday, TimeFrom = 780, TimeTo = 840 }
    	};
    
    
    	var byDay = schedules.GroupBy(i => i.DayOfWeek)
    				.Select(i =>
    				{
    					var times = i.Select(t => string.Format(@"{0:hh\:mm}-{1:hh\:mm}", TimeSpan.FromMinutes(t.TimeFrom), TimeSpan.FromMinutes(t.TimeTo)));
    					return string.Format("{0}: {1}", i.Key, string.Join("; ", times));
    				});
    
    	foreach (var day in byDay)
    	{
    		Console.WriteLine(byDay);
    	}
    }
    
    public class Schedule
    {
    	public bool IsOn { get; set; }
    	public DayOfWeek DayOfWeek { get; set; }
    	public short TimeFrom { get; set; } // store time as amount of minutes since start of day
    	public short TimeTo { get; set; } // store time as amount of minutes since start of day
    }
