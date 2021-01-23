    public class ChartDataMonthly
    {
        public List<decimal[]> Temperature { get; set; }
        
        // This can be "unmapped" to ignore object mappers
        public List<string> RoundedTemperature 
        { 
            get
            {
                return Temperature.Select(t => Math.Round(t).ToString()).ToList();
            }
        }
        // rest of model
    }
