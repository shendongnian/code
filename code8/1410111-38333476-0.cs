    [ComplexType]
    public class Math
    {
    
        public int first { get; set; }
        public int second { get; set; }
       
        [NotMapped] 
        public int sum
        {
            get
            {
               return first + second;
            }
        }
    }
