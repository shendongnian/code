    static void Main(string[] args)
    {
        Batch batch = new Batch() { ID = 1, StartTime = DateTime.Now, EndTime = DateTime.Now, Duration = 10 };
    
        batch.Print(new FileLogger());
        batch.Print(new ConsoleLogger());
    }
    
    public class Batch
    {
        public int ID { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
        public double Duration { set; get; }
    
        public void Print(ILogger logger)
        {
            logger.Log(this.ToString());
        }
    
        public override string ToString()
        {
            return $"ID = {ID} ** StartTime = {StartTime} ** EndTime = {EndTime} ** Duration = {Duration}";
        }
    }
    
    public interface ILogger
    {
        void Log(string text);
    }
    
    public class ConsoleLogger : ILogger
    {
        public void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
    
    public class FileLogger : ILogger
    {
        string filePath = "log.txt";
    
        public void Log(string text)
        {
            File.AppendAllText(filePath, text);
        }
    }
