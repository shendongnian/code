	public class Entry
	    {
	        public string key { get; set; }
	        public object value { get; set; }
	    }
	
	    public class Detail
	    {
	        public List<Entry> entry { get; set; }
	    }
	
	
	    public class Device
	    {
	        public List<Detail> details { get; set; }
	    }
		
	void Main()
	{
		var json = @"
		{
		  ""irrelevant"": ""fnord"",
		  ""also_irrelevant"": [1,3,5,7],
		  ""details"": [
		   {
		     ""not_entry"": true,
		     ""entry"": [
			   {
			     ""key"": ""x"",
			     ""value"": ""1""
			   },
			   {
			     ""key"": ""y"",
			     ""value"": ""2""
			   }
			 ]
		   },
		   {
		     ""entry"": [
			   {
			     ""key"": ""a"",
			     ""value"": ""3"",
				 ""bummer"": ""hello""
			   },
			   {
			     ""key"": ""b"",
			     ""value"": ""4"",
				 ""bummer"": ""hello""
			   }
			 ]
		   }
		  ]
		}";
		
		Newtonsoft.Json.JsonConvert.DeserializeObject<Device>(json).Dump();
	}
