    public class Temperature
    {
        public Temperature(double value, TemperatureUnit unit) { 
           Value = ConvertValue(value, unit, TemperatureUnit.Celsius);
        }
   
        private double Value { get; set; }
    
        private double ConvertValue(double value, TemperatureUnit originalUnit,  TemperatureUnit targetUnit)
        {
           /* return value from originalUnit converted to targetUnit */
        }
        private double GetValue(TemperatureUnit unit)
        {
           return ConvertValue(value, TemperatureUnit.Celsius, unit);
        }    
        public override bool Equals(object obj)
        {
            Temperature other = obj as Temperature;
            if (other == null) { return false; }
            return (Value == other.Value);
        }
    
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
