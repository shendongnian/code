    using System.Collections.Generic;
    
    namespace HelloWorldMvcApp
    {
    	public class SystemStatusRules
    	{
    		public struct EmailItem
    		{
    			public int EmailSubject_Id;
    			public bool IsSubject;
    			public string Email_String;
    			public int StatusCode;
    		}
    
    		public List<EmailItem> EmailItems { get; set; }
    	}
    }
