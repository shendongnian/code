    public class Test
    {
    	public ObjectId _id;
        public string ticker;
        public string exchange;
        public string localtick;
        public string compname;
        public string currency;
        public DateTime insertedtime;
    }
    
    var query = db.GetCollection<Test>("test")
        .AsQueryable()
        .Where(c => c.ticker.Contains("=CA"));
