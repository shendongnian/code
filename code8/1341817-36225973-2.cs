    public class ClassA 
    {
      string X {get; set;}
      string Y {get; set;}
    }
     public static class myClassExtensions
     {
    	public static void ConvertNullToStringEmpty<T>(this T clsObject) where T : class
    	{
    		PropertyInfo[] properties = clsObject.GetType().GetProperties();//typeof(T).GetProperties();
    		foreach (var info in properties)
    		{
    			// if a string and null, set to String.Empty
    			if (info.PropertyType == typeof(string) && info.GetValue(clsObject, null) == null)
    			{
    				info.SetValue(clsObject, String.Empty, null);
                    // or set some boolean etc since you know the property at this point is of type string
    			}
    		}
    	}
    }	
