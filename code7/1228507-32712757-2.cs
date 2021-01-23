    using System;
    using System.Collections.Generic;
    
    public class Properties
    {
        public IDictionary<string, string> ExtendedProperties { get; set; }
        
        public Properties(string name, string number, string age) 
        {
        	this.ExtendedProperties = new Dictionary<string, string>() 
        	{ 
        		["Name"] = name,
        		["Number"] = number,
                ["Age"] = age
        	};
        }
    }
