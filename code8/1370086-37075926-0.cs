    public class Deposite
    {
        public int id { get; set; }
        public date date { get; set; }
        public double amount { get; set; }
        public int transID { get; set; }
    	public string Memo { get; set; }
    	public string status { get; set; }
    }
    
    public class Withdrawal
    {
        public int id { get; set; }
        public date date { get; set; }
        public double amount { get; set; }
        public int transID { get; set; }
    	public string Memo { get; set; }
    	public string status { get; set; }
    }
    
    public class results
    {
        public int id { get; set; }
        public int tp_id{ get; set; }
    	public string firstname { get; set; }
    	public string lastname { get; set; }
    	public string email { get; set; }
    	public string phone { get; set; }
    	public string enrolled { get; set; }
    	public string balance { get; set; }
    	public string fleet { get; set; }
        public Deposite[] deposite { get; set; }
    	public Withdrawal[] withdrawal { get; set; }
    }
    public class opt
    {
        public results[] response { get; set; }
    }
    
    using System.Web.Script.Serialization;
    
    JavaScriptSerializer objJS = new JavaScriptSerializer();
    opt objopt  = new opt();
    objopt  = objJS .Deserialize<opt >("Your String");
