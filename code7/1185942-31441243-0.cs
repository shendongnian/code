    class Program
    {
        static void Main(string[] args)
        {
            Hour hour = new Hour("20150715 080000");
            Day day = new Day(hour);
            Console.WriteLine(String.Format("Hour: {0}", hour.OutputMoment()));
            Console.WriteLine(String.Format("Day: {0}", day.OutputMoment()));
        }
    }
    public abstract class Moment
    {
        public string Date;
        public string Time;
        public virtual string OutputMoment()
        {
            return Date + " " + Time;
        }
        public override string ToString()
        {
            return OutputMoment();
        }
    }
    
    class Hour : Moment
    {
        public Hour(string s)
        {
            string[] parts = s.Split(';');
            this.Date = parts[0];
            this.Time = parts[1];
        }
    }
    class Day : Moment
    {
        public Day(Hour hour)
        {
            this.Date = hour.Date;
            this.Time = hour.Time;
        }
    }
