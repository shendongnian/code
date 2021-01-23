    void Main()
    {
    	// To directly connect to a single MongoDB server
        // or use a connection string
        var client = new MongoClient("mongodb://localhost:27017");
    	var database = client.GetDatabase("test");
    	
    var collectionEmpInfo = database.GetCollection<Employee>("Employee");
    Employee EmpInfo = new Employee
    {
        
    	EmpID = "103",
        EmpName = "John",
    	CreatedAt = DateTime.Now,
        EmpMobile = new List<Mobile>
        {
            new Mobile{ MobNumber = "55566610", IsPreferred = true, MobID = ObjectId.GenerateNewId() },
            new Mobile{ MobNumber = "55566611", IsPreferred = false, MobID = ObjectId.GenerateNewId() },
        }
    };
    //collectionEmpInfo.InsertOne(EmpInfo);
    
    var filterDef = new FilterDefinitionBuilder<Employee>();
    var filter = filterDef.In(x=>x.EmpID , new[]{"101","102"});
    filter.Dump();
    var empList = collectionEmpInfo.Find(filter).ToList();
    empList.Dump();
    }
    public class Employee
    {
       public ObjectId Id  { get; set; }
    	public string EmpID { get; set; }
        public string EmpName { get; set; }
        public List<Mobile> EmpMobile { get; set; }
    	public DateTime CreatedAt { get; set; }
    }
    
    public class Mobile
    {
        public ObjectId MobID { get; set; }
        public string MobNumber { get; set; }
        public bool IsPreferred { get; set; }
    }
