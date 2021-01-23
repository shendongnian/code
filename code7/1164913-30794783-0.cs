    using System;
    
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    
    		var sent = new List<Sent>()
    		{
    			new Sent { Address = "04004C", Data = "55AA55" },
    			new Sent { Address = "040004", Data = "0720" },				
    			new Sent { Address = "040037", Data = "31" },				
    			new Sent { Address = "04004A", Data = "FFFF" }
    		};
    
    
    		var res = new List<Result> () {
    			new Result { AddressOK = "04004C", DataOK = "55AA55" },
    			new Result { AddressOK = "040004", DataOK = "0721" },				
    			new Result { AddressOK = "040038 ", DataOK = "31" },				
    			new Result { AddressOK = "04004A", DataOK = "FFFF" }
    
    		};
    
    		var diff =
    			sent.Where (s => !res.Any (r => s.Address == r.AddressOK && s.Data == r.DataOK ));
    				
    	
    		foreach (var item in diff) 
            {
    			Console.WriteLine("{0} {1}", item.Address, item.Data);
    		}
    
    	}
    }
    
    
    public class Sent
    {
    	public string Address;
    	public string Data;
    }
    
    
    public class Result
    {
    	public string AddressOK;
    	public string DataOK;
    }
