    public class BaseClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    
    public class SubClassOne : BaseClass
    {
        [Column("Volume1")]   
        public double Volume { get; set; }        
    }
    
    public class SubClassTwo : BaseClass
    {
        [Column("Volume2")] 
        public double Volume { get; set; }
    }
    
    public class SubClassThree : BaseClass
    {
        public int Number { get; set; }
    }
