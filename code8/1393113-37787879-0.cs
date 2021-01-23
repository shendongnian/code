	void Main()
	{
		// To directly connect to a single MongoDB server
		// or use a connection string
		var client = new MongoClient("mongodb://localhost:27017");
		var database = client.GetDatabase("test");		
	var collectionEmpInfo = database.GetCollection<Employee>("Employee");
	Employee EmpInfo = new Employee
	{		
		EmpID = "100",
		EmpName = "John",
		EmpMobile = new List<Mobile>
		{
			new Mobile{ MobNumber = "55566610", IsPreferred = true, MobID = ObjectId.GenerateNewId() },
			new Mobile{ MobNumber = "55566611", IsPreferred = false, MobID = ObjectId.GenerateNewId() },
		}
	};
	collectionEmpInfo.InsertOne(EmpInfo);
	var empList = collectionEmpInfo.Find(new BsonDocument()).ToList();
	empList.Dump(); //dump is used in linqPad
	}
	public class Employee
	{
	   public ObjectId Id  { get; set; }
		public string EmpID { get; set; }
		public string EmpName { get; set; }
		public List<Mobile> EmpMobile { get; set; }
	}
	public class Mobile
	{
		public ObjectId MobID { get; set; }
		public string MobNumber { get; set; }
		public bool IsPreferred { get; set; }
	}
