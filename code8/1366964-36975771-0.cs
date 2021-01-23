    public class MeasuringDevice_Helper
    {
        private const int LIMIT = 10;   // This is a constant value, so should be defined IN_CAPS in class definition
        List<double> metricValues = new List<double>(LIMIT);    // This needs to be at class level so it doesn't get lost
        Random rnd = new Random();  // This is used frequently so define at class level
        public void GenerateMetricValue()  // This is now named like the action it performs
        {
            Console.WriteLine("Current metric values = " + metricValues.Count);
            
            if (metricValues.Count < LIMIT)     // This should just be < not <=
            {
                float rndInt = rnd.Next(1, 10);
                double rndDouble = rndInt / 10.0;   // An Int divided by Int will = Int
                Console.WriteLine("Added " + rndDouble);
                metricValues.Add(rndDouble);
            }
            else
            {
                Console.WriteLine("limit reached");
            }
        }
        public double PopOldestMetricValue()
        {
            double value = metricValues[0];
            metricValues.RemoveAt(0);
            return value;
        }
    }
