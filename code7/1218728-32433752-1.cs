    using System;
    using System.ComponentModel.DataAnnotations;
    
    namespace HelloWorldMvcApp
    {
    	public class SampleModel
    	{
    		[Display(Name = "Weight Form")]
        	public int? WeightFrom { get; set; }
    		
    		[Display(Name = "Weight To")]
        	public int? WeightTo { get; set; }
    		
    		[Required]
    		[Display(Name = "Name")]
        	public string Name { get; set; }
    	}
    }
