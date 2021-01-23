    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string restResponse = "OK";
    		
            // Creates an AddAccountResponse
        	var response = GetResponse<AddAccountResponse>(restResponse);
    		response.AccountNumber = 0;
    	}
    	
        // I converted your `GetResponse` to a generic method `GetResponse<T>`. 
        // The method expects that `T` is (derived from) a `BaseResponse` 
        // and that `T` has a parameterless constructor. 
    	private static T GetResponse<T>(string restResponse) where T : BaseResponse, new()
    	{
    		var response = new T();
    		response.StatusCode = restResponse;
    		return response;		
    	}
    }
    
    public class BaseResponse
    {
    	public string StatusCode { get; set; }
    }
    
    public class AddAccountResponse : BaseResponse
    {
    	public int AccountNumber { get; set; }
    }
