    public class TransformStep : IStep<int, char>
    {
        public IObservable<char> Transform(IObservable<int> source)
        {
            return source.Map(IntToChar); 
        }
        public char IntToChar(int value)
        {
            return (char)(value + 64);
        }
    }
    public class ReportStep : IStep<char, char>
    {
        private readonly Logger logger;
        public ReporterStep(Logger logger)
        {
          this.logger = logger;
        }
        public IObservable<char> Transform(IObservable<char> source)
        {
            return source.Do(Report);
        }
        public void Report(char value)
        {
            Console.WriteLine("Report '{0}'", value);
        }
    }
