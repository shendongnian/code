    public class myTableEntity
    {   
        [Key, Column(Order=0)]
        public int foo {get; set;}
        
        [Key, Column(Order=1)]
        public int bar {get; set;}
    }
