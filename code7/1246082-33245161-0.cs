    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string json = "[{\"id\":1,\"barcode\":\"TestBARCODE\",\"nsr\":0,\"stk_in\":0,\"stk_out\":0,\"sales\":0,\"balance\":1},{\"id\":2,\"barcode\":\"TestBARCODE2\",\"nsr\":0,\"stk_in\":0,\"stk_out\":0,\"sales\":0,\"balance\":1},{\"id\":3,\"barcode\":\"TestBARCODE3\",\"nsr\":0,\"stk_in\":0,\"stk_out\":0,\"sales\":0,\"balance\":1},{\"id\":4,\"barcode\":\"AAA\",\"nsr\":0,\"stk_in\":0,\"stk_out\":0,\"sales\":0,\"balance\":1},{\"id\":5,\"barcode\":\"BBB\",\"nsr\":0,\"stk_in\":0,\"stk_out\":0,\"sales\":0,\"balance\":1}]";
    		var movies = JsonConvert.DeserializeObject<List<Movie>>(json);
    		foreach (var movie in movies)
    		{
    			Console.WriteLine("Movie Id : " + movie.Id + " BarCode : " + movie.Barcode);
    		}
    	}
    	
    }
    
    public class Movie
    {
    	public int Id {get; set; }
    	public string Barcode {get; set; }
    	public int NSR {get; set; }
    	
    	
    	public int Stk_in {get; set; }
    	public int Stk_out {get; set; }
    	
    	public int Balance {get; set; }
    	
    }
