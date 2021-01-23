    public class MyModel
    {
        public IList<OneSetOfElements> FormSet { get; set; }
    }
    
    public class OneSetOfElements
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
    }
