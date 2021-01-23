    using System;
    using System.ComponentModel;
    using System.Reflection;
    using System.Linq;
    
    public enum BusinessCategory
    {
       [Description("Computers & Internet")]
       ComputersInternet = 1,
       [Description("Finance & Banking")]
       FinanceBanking = 2,
       [Description("Healthcare")]
       Healthcare = 3,
       [Description("Manufacturing")]
       Manufacturing = 4
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		// Get all possible values
    		var values = Enum.GetValues(typeof(BusinessCategory)).Cast<BusinessCategory>();
    		foreach(var v in values)
    		{
    			// Write to the console info about each value
    			Console.WriteLine("{0}[{1}] => {2}", v, (int)v, v.GetEnumDescription());
    		}
    	}
    }
    
    public static class EnumExtensions
    {
    	public static string GetEnumDescription(this Enum value, string defaultValue = null)
    	{
    		return value.GetEnumAttribute<DescriptionAttribute>(a => a.Description, defaultValue);
    	}
    
    	private static string GetEnumAttribute<TAttr>(this Enum value, Func<TAttr, string> expr, string defaultValue = null)where TAttr : Attribute
    	{
    		FieldInfo fi = value.GetType().GetField(value.ToString());
    		var attributes = fi.GetCustomAttributes<TAttr>(false).ToArray();
    		return (attributes != null && attributes.Length > 0) ? expr(attributes.First()) : (defaultValue ?? value.ToString());
    	}
    }
