    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    public class Program
    {
    	public static void Main()
    	{
    		List<Man> Men = new List<Man>();
    		
    		Man m1 = new Man();
    		m1.Number = "+1-9169168158";
    		m1.Message = "Hello Bob from 1";
    		m1.UniqueCode = "0123";
    		m1.State = 0;
    		
    		Man m2 = new Man();
    		m2.Number = "+1-9296146182";
    		m2.Message = "Hello Bob from 2";
    		m2.UniqueCode = "0125";
    		m2.State = 0;
    
    		Men.AddRange(new Man[] { m1, m2 });
    	
    		string result = JsonConvert.SerializeObject(Men);
    		Console.WriteLine(result);	
    
    		List<Man> NewMen = JsonConvert.DeserializeObject<List<Man>>(result);
         	foreach(Man m in NewMen) Console.WriteLine(m.Message);
    	}
    }
    public class Man
    {
    	public string Number{get;set;}
    	public string Message {get;set;}
    	public string UniqueCode {get;set;}
    	public int State {get;set;}
    }
