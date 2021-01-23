    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var json = "{ \"price\": [ 10, 20 ] }";
    		var json2 = "{ \"price\": 15 }";
    		
    		var foo1 = JsonConvert.DeserializeObject<Foo>(json);
    		var foo2 = JsonConvert.DeserializeObject<Foo>(json2);
    		
    		foo1.Price.ForEach(Console.WriteLine);
    		foo2.Price.ForEach(Console.WriteLine);
    	}
    }
    
    public class Foo {
    	[JsonProperty(PropertyName = "price")]
    	public dynamic priceJson { get; set; }
    	
    	private List<int> _price;
    	
    	public List<int> Price {
    		get {
    			if (_price == null) _price = new List<int>();
    			
    			_price.Clear();
    			
    			if (priceJson is Newtonsoft.Json.Linq.JArray) {
    				
    				foreach(var price in priceJson) {
    					_price.Add((int)price);
    				}
    			} else {
    				_price.Add((int)priceJson);
    			}
    			
    			return _price;
    		}
    	}
    }
