    using NodaTime.Text;
    
    namespace Program
    {
        class Program
        {
            static void Main(string[] args)
            {
                DurationPattern pattern = DurationPattern.CreateWithInvariantCulture("+hhmm");
                TimeSpan timeSpan = pattern.Parse("+0100").Value.ToTimeSpan();
            }
        }
    }
