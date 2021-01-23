    public class table1
    {
         public string name1 { get; set; }
    }
    
    public class table2
    {
         public string name2 { get; set; }
    }
    
    public class bothTable
    {
         public List<table1> table1 { get; set; }
         public List<table2> table2 { get; set; }
    }
