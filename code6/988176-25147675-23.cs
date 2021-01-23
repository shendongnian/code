    using System;
    using System.Reflection;
    
    public class Test
    {
    	public enum CurrencyId {
    	    USD = 840,
    	    UAH = 980,
    	    RUR = 643,
    	    EUR = 978,
    	    KZT = 398,
    	    UNSUPPORTED = 0
    	}
    	public static void Main()
    	{
    		foreach(FieldInfo fi in typeof(CurrencyId).GetFields())
    			if(fi.IsStatic) Console.WriteLine(fi.Name);
    	}
    }
