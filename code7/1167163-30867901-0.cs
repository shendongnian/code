    void Main()
    {
	    string obj = @"{ 
	    	""SERVER1/DeviceIpint.3/SourceEndpoint.video:0:0"" : 
	    	{
	    		""origin"" : ""SERVER1/DeviceIpint.3/SourceEndpoint.video:0:0"",
	    		""state"" : ""connected"",
	    		""friendlyNameLong"" : ""Camera 3"",
	    		""friendlyNameShort"" : ""3""
	    	},
	    	""SERVER2/DeviceIpint.5/SourceEndpoint.video:0:0"" : 
	    	{
		    	""origin"" : ""SERVER2/DeviceIpint.5/SourceEndpoint.video:0:0"",
		    	""state"" : ""disconnected"",
		    	""friendlyNameLong"" : ""Camera 5"", 
		    	""friendlyNameShort"" : ""5"" 
		    }
	    }";
	
	    VideoSource s = new VideoSource();
	    dynamic source = JsonConvert.DeserializeObject<Dictionary<string, VideoSource>>(obj);
	    foreach(var videoSource in source)
	    {
		    s.origin = videoSource.Value.origin;
		    s.friendlyNameLong = videoSource.Value.friendlyNameLong;
		    s.friendlyNameShort = videoSource.Value.friendlyNameShort;
	    	s.state = videoSource.Value.state;
	    	s.Dump();
	    }
    }
    
    // Define other methods and classes here
    public class VideoSource
    {
        public string origin { get; set; }
        public string state { get; set; }
        public string friendlyNameLong { get; set; }
        public string friendlyNameShort { get; set; }
    
        public override string ToString()
        {
            return origin;
        }
    }
