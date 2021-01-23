    public class Program
    {
	  public static void Main()
	  {
		Foo fc = new Foo();
		
		var required = fc.GetType().GetCustomAttributes(typeof(ImportParameter), true)
            .Select(p => ((ImportParameter)p).Required).ToList();
		required.ForEach(Console.WriteLine);
	  }
    }
    public class ImportParameter : System.Attribute
    {
      public Boolean Required {get; private set;}
      public ImportParameter(Boolean required)
      {
        this.Required = required;
      }
    }
    [ImportParameter(false)]
    public class Foo 
    {
	  public String Test = "Test";
    }
