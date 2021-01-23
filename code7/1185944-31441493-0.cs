    public interface IMoment
    { 
       string MomentType {get;}
       string Date {get;set;}
       string Time {get;set;}
    }
    
    
    public class Hour:IMoment
    {
        public string MomentType {get{return "Hour";}}
    	public string Date {get;set;}
        public string Time {get;set;}
    
        public Hour (string s)
        {
            string[] parts = s.Split(';');
            this.Date = parts[0];
            this.Time = parts[1];
        }
    }
    
    public class Day: IMoment
    {
        public string MomentType {get{return "Day";}}
        public string Date{get;set;}
        public string Time{get;set;}
    
        public Day(Hour hour)
        {
            this.Date = hour.Date;
            this.Time = hour.Time;
        }
    }
    
    public class ConsoleMomentWriter
    {
       public void Write(IMoment moment)
       {
          Console.WriteLine("{0}: {1} {2}",moment.MomentType,moment.Date,moment.Time);
       }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Hour hour = new Hour("20150715 080000");
            Day day = new Day(hour);
            var writer = new ConsoleMomentWriter();
    		writer.Write(hour);
    		writer.Write(day);
        }
    }
