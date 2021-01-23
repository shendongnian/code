    using System;
    using System.Collections.Generic;
    
    class Foo {
        public string GetSchedules(string request)
        {
            return Worker((c) => c[request]);
        }
        
        public string GetCountryList(string request)
        {
            return Worker((c) => c[request].ToUpper());
        }
        
        public string GetCarriers(string request)
        {
            return Worker((c) => c[request].ToLower());
        }
        
        private string Worker(Func<Dictionary<string,string>, string> f)
        {
            var d = new Dictionary<string, string>();
            d.Add("1", "One");
            d.Add("2", "Two");
            d.Add("3", "Three");
            return f(d);
        }
    }
    
    public class Test
    {
    	public static void Main()
    	{
    		var f = new Foo();
    		Console.WriteLine(f.GetSchedules("1"));
    		Console.WriteLine(f.GetCountryList("1"));
    		Console.WriteLine(f.GetCarriers("1"));
    	}
    }
