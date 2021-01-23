    using System;
    using System.Collections.Generic;
    
    public class Properties
    {
        private IDictionary<string, string> extendedProperties;
        
        public string this[string key] 
        {
        	get { return extendedProperties[key]; }
        	set { extendedProperties[key] = value; }    	
        }
        
        public Properties() 
        {
        	this.extendedProperties = new Dictionary<string, string>() 
        	{ 
        		["Name"] = "something",
        		["Number"] = "something",
                ["Age"] = "something"
        	};
        }
    }
