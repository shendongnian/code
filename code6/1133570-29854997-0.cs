	    var results = Database.SqlQuery<TestResult>("select r.Name, b.BankName from relation r inner join BankAccount b on b.RelationId = r.Id where r.Id = 2");
	    results.Dump();
	}
	
	public class TestResult {
	    public string Name { get; set; }
	    public string BankName { get; set; }
