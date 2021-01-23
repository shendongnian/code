    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class TObject
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		List<TObject> list = new List<TObject>();
    		
    		for(int i = 0; i < 100; i++)
    		{
    			list.Add(new TObject());
    			list[i].StartTime = (i == 0 ? DateTime.Now : list[i-1].EndTime.AddMinutes(i + 1));
    			list[i].EndTime = list[i].StartTime.AddMinutes(i);
    			Console.WriteLine(list[i].StartTime + " - " + list[i].EndTime);
    		}
    		
    		int threshold = 20;
    		
    		var withinThreshold = list.Where(x => list.Where(y => y.StartTime < x.StartTime && y.EndTime.AddMinutes(threshold) > x.StartTime).Any()).Select(x => x).ToList();
    		Console.WriteLine("Within threshold: ");
    		withinThreshold.ForEach(x => Console.WriteLine(x.StartTime + " - " + x.EndTime));
    	}
    }
