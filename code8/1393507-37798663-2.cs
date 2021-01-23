    public class ItemsData
    {
        public string value0 { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public string value4 { get; set; }
        
        public string AllValues 
        {
            get 
            {
                return $"{value0} {value1} {value2} {value3} {value4}";
            }
        }
        public override string ToString()
        {
            return AllValues;
        }
    }
