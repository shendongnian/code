    using System;
    using System.Collections;
    using System.Collections.Generic;
    namespace TestProject
    {
    	/// <summary>
    	/// Parameter entry for ParameterTypes collection.
    	/// </summary>
    	class ParameterEntry : Dictionary<string, object>
    	{
            // this is just an subclassed Dictionary class
    	}
	
    	/// <summary>
    	/// Parameter types collection.
    	/// </summary>
    	class ParameterTypes : Dictionary<string, ParameterEntry>
    	{
            // this class is a Dictionary that holds ParameterEntry objects
            
    		/// <summary>
    		/// Add the specified value using its name as the key.
    		/// </summary>
    		/// <param name='value'>
    		/// A parameter entry.
    		/// </param>
    		public void Add(ParameterEntry value)
    		{
    			string key = (string)value["name"];
    			this.Add(key, value);
    		}
    	}
	
    	class TestProject
    	{
    		public static void Main (string[] args)
    		{
    			var entry1 = new ParameterEntry();
    			entry1.Add("name", "EVENT_PARAM_SCTP_SHUTDOWN_RESULT");
    			entry1.Add("usevalid", "Yes");
    			entry1.Add("description", "The results of a SCTP Shutdown");
    			entry1.Add("numberofbytes", 1);
    			entry1.Add("type", "ENUM");
			    
    			var entry2 = new ParameterEntry();
    			entry2.Add("name", "EVENT_PARAM_ENBS1APID");
    			entry2.Add("numberofbytes", 3);
    			entry2.Add("usevalid", "Yes");
    			entry2.Add("description", "eNB S1 AP ID");
    			entry2.Add("resolution", 1);
	    		entry2.Add("type", "UINT");
			    
    			var types = new ParameterTypes();
    			types.Add(entry1);
    			types.Add(entry2);
    			
    			Console.WriteLine(types["EVENT_PARAM_ENBS1APID"]["name"]);
    			Console.WriteLine(types["EVENT_PARAM_ENBS1APID"]["numberofbytes"]);
    			Console.WriteLine(types["EVENT_PARAM_ENBS1APID"]["usevalid"]);
    			Console.WriteLine(types["EVENT_PARAM_ENBS1APID"]["description"]);
    		}
    	}
    }
