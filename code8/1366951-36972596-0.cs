    public class Reading
    {
        [JsonIgnore]
        public double? Temperature { get; set; }
    
        [JsonProperty("temperature")]
        private string TemperatureString 
        {
            get
            {
                return Temperature.HasValue ? Temperature.Value.ToString() :"NA";
            }
            set
            {
                double result;
                Temperature = double.TryParse(value, out result) ? result : null;
            }
        }
    }
