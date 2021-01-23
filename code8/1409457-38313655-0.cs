    public class ChartDataMonthly
    {
        public List<decimal[]> Temperature { get; set; }
        
        // This can be "unmapped" to ignore object mappers
        public string RoundedTemperature 
        { 
            get
            {
                return Math.Round(Temperature).ToString();
            }
        }
        // rest of model
    }
