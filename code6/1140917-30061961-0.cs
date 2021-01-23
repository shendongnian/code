    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json; 
    					
    public class Program
    {
    	
    	public static void Main()
    	{
    		var info = new DocInfo(){
    			CustomerInfo = new CustomerInfo(){Name = "A", Adress = "B"},
    			ProductInfo = new ProductInfo(){Name = "A", Price = "1"},
    			Whatever = new Whatever(){Property1 = "1", Property2 = "2"}	
    		};
    		var output =  JsonConvert.SerializeObject(info);
    		Console.WriteLine(output);
    	}
    }
    
    public class DocInfo{
    	public CustomerInfo CustomerInfo{get;set;}
    	public ProductInfo ProductInfo{get;set;}
    	public Whatever Whatever{get;set;}
    }
    
    public class CustomerInfo{
    	public string Name{get;set;}
    	public string Adress{get;set;}
    	
    }
    	
    
    public class ProductInfo{
    	public string Name{get;set;}
    	public string Price{get;set;}
    	
    }
    
    
    public class Whatever{
    	public string Property1{get;set;}
    	public string Property2{get;set;}
    	
    }
    	
