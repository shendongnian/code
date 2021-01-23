    using System;
    using System.Linq;
    					
    public class Program
    {
    	[ImportParameter(false)]
    	public Foo fc {get;set;}
    	
    	public static void Main()
    	{		
    		var required = typeof(Program).GetProperties()
                .SelectMany(p => p.GetCustomAttributes(true)
                              .OfType<ImportParameter>()
    						  .Select(x => new { p.Name, x.Required }))
    			.ToList();
    		
    		required.ForEach(x => Console.WriteLine("PropertyName: " + x.Name + " - Required: " + x.Required));
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
    
    public class Foo 
    {
    	public String Test = "Test";
    }
