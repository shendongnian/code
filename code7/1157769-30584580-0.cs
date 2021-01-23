    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    				
    public class A
    {
       	[Required]
    	public string Text{get;set;}	
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		List<ValidationResult> errors = new List<ValidationResult>();
    		
    		if(Validator.TryValidateObject(new A(), null, errors))
    		{
    			// Do stuff if object validates
    		}
    	}
    }
