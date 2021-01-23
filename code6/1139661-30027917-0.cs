    var dataset = new List<MyClass>();
    
    public class MyClass
    {
        public string Label {get; set;}
        public List<List<string>> data {get;set;}
        public string Color {get; set;}      
        public MyPoint Points {get; set;}
        public MyLine Lines {get; set;}
    }
    public class MyPoint
    {
       public string FillColor {get;set;}
       public bool Show {get;set;}
    }
    
    public class MyLine
    {
       public bool Show { get; set;}
    }
