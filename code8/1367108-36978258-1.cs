    using System;
    using System.Reflection;
    using System.Linq.Expressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		YourClass c = new YourClass() {
    			PropA = 1,
    			PropB = 2,
    			PropC = "ciao"
    		};
    		
    		
    		var propBValue = c.Field<int>("PropB");
    		Console.WriteLine("PropB value: {0}", propBValue);
    		
    		var propCValue = c.Field<string>("PropC");
    		Console.WriteLine("PropC value: {0}", propCValue);
    	}
    }
    
    
    
    public static class EntityExtension {
       public static T Field<T>(this object entity, string field) {
    	   Type entityType = entity.GetType();
    	   PropertyInfo propertyInfo = entityType.GetProperty(field);
    	   if (propertyInfo == null) {
    		   throw new ArgumentException(string.Format("{0} doesn't exist on {1}", field, entityType.Name));
    	   }
    	   
    	   return (T)propertyInfo.GetValue(entity);
       }
    }
    
    public class YourClass {
    	public int PropA { get; set; }
    	public int PropB { get; set; }
    	public string PropC { get; set; }
    }
