    void Main()
    {
    	 var modelList = new Model2();
            modelList.MyPropertyList.Add(new Model1 { Name = "Hej1", MyProperty1 = true });
            modelList.MyPropertyList.Add(new Model1 { Name = "Hej2", MyProperty1 = false });
            var test = modelList.MyPropertyList.Find(x => x.Name == "Hej1").MyProperty1;
    		Console.WriteLine (test);
    }
    
    
    public class Model1
    {
     public string Name { get; set; }
     public bool? MyProperty1 { get; set; }
    }
    
    public class Model2
    {
     public List<Model1> MyPropertyList { get; set; }
     public Model2()
     {MyPropertyList = new List<Model1>();
     }
    }
