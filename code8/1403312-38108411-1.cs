    using Dapper;
    public class FamilyModel
    {
    	public int Id { get; set;}
    	public string FamilyName { get; set; }
    	public List<Person> Members { get; set; } = new List<Person>();//Initializer for Auto-Property, C#6<= only
    }
    public class Person
    {
    	public int Id { get; set;}
    	public string Name { get; set; }
    }
    public class DatabasePOCO
    {
    	public string FamilyName { get; set; }
    	public string ChildName { get; set; }
    	public int Fid { get; set; }
    	public int Id { get; set;}
    }
    void Main()
    {
    	using (IDbConnection conn = new SqlConnection("..."))
    	{
    		conn.Open();
    		var raw = conn.Query<DatabasePOCO>("sp_GetFamilies",
    		commandType: CommandType.StoredProcedure);//Could be dynamic, not typed
    		var familyList = raw
    		.GroupBy(x => x.Fid)
    		.Select(x =>
    		{
    			var rawMembers = x.ToList();
    			var fId = x.First().Fid;
    			var fName = x.First().FamilyName;
    			var members = rawMembers.Select(y => new Person 
    			{
    				Id = y.Id,
    				Name = y.ChildName
    			});
    			return new FamilyModel
    			{
    				Id = fId,
    				FamilyName = fName,
    				Members = members.ToList()
    			};
    		});
    		//Whatever else you want to do here
    	}
    }
