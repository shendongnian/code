    public class Flight
    {
    		public string begin_date {get;set;}
    		public string end_date {get;set;}
    		public string query_type {get;set;}
    		public List<Sorties> sorties{get;set;}
	        public string sum_dt {get;set;}
			public string first_tkof {get;set;}
			public string last_ldg {get;set;}
			public string max_dalt {get;set;}
    }
    public class Sorties
    {
    	public string id {get;set;}
    	public string cs {get;set;}
    	public string launch {get;set;}
    	public string tow_id {get;set;}
    	public string tow_name {get;set;}
    	public int type {get;set;}
    	public string date {get;set;}
    	public Tkof tkof{get;set;}
    	public Ldg ldg{get;set;}
    	public string dalt{get;set;}
    	public string dt{get;set;}
    		
    		
    }
    public class Tkof
    {
    	public string time {get;set;}
    	public string loc {get;set;}
    	public string rwy {get;set;}
    }
    public class Ldg
    {
    	public string time {get;set;}
    	public string loc {get;set;}
    	public string rwy {get;set;}
    }
    Usage
    var json = "....."
    var flightsList = JsonConvert.DeserializeObject<Flight>(json);
    var sorties = flightsList.sorties;
    foreach(var sorty in sorties)
    {
	 //use object
    }
