    public class Record
    {
        // Each of the data
        public string month;
        public int afDays;
        public int years;
        public double rainfall;
        public double sunshineHours;
        public double maxTemp;
        public double minTemp;
    
        // Constructor
        public Record(string newMonth, int newAfDays, int newYears,
            double newRainfall, double newSunshine, double newMaxTemp, double newMinTemp)
        {
            // Set the instance variables to each of the given values.
            month = newMonth;
            afDays = newAfDays;
            years = newYears;
            rainfall = newRainfall;
            sunshineHours = newSunshine;
            maxTemp = newMaxTemp;
            minTemp = newMinTemp;
        }
    
        public static Dictionary<int, Record> getRecords(string[] months, int[] afDays, int[] years,
            double[] rainfall, double[] sunshineHours, double[] maxTemp, double[] minTemp)
        {
            return months.Select((m, i) => new Record(months[i], afDays[i], years[i],
                rainfall[i], sunshineHours[i], maxTemp[i], minTemp[i])).ToDictionary(r => r.years);
        }
    }
