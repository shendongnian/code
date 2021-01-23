        public decimal GetValuesFromDictionary(Dictionary<string, decimal> values)
        {
            Jan = GetValueFromKey(values, "Jan");
            Feb = Jan + GetValueFromKey(values, "Feb");  
            Mar = Feb + GetValueFromKey(values, "Mar");
            Apr = Mar + GetValueFromKey(values, "Apr");
            May = Apr + GetValueFromKey(values, "May");
            Jun = Apr + GetValueFromKey(values, "Jun"); 
            Jul = Jun + GetValueFromKey(values, "Jul");
            Aug = Jul + GetValueFromKey(values, "Aug");
            Sep = Aug + GetValueFromKey(values, "Sep");
            Oct = Sep + GetValueFromKey(values, "Oct"); 
            Nov = Oct + GetValueFromKey(values, "Nov");
            Dec = Nov + GetValueFromKey(values, "Dec");
            return Dec;
        }
        private decimal GetValueFromKey(Dictionary<string,decimal> values, string key)
        {
            decimal temp;
            values.TryGetValue(key, out temp);
            return temp;
        }
