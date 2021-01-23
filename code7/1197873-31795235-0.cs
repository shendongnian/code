    public class Program
    {
    	
    	public static void Main()
    	{
    		Thingy t = new Thingy();
            // Note execution is deferred until enumeration (in this case Count())
    		var allData = t.GetData();
    		Console.WriteLine("All Data count: {0}", allData.Count());
    
            // Select only valid records from data set (should be 2)
    		var isValid = t.GetData();
    		isValid = isValid.Where(w => w.IsValid);
    		Console.WriteLine("IsValid count: {0}", isValid.Count());
    		
            // select only records with an ID greater than 1 (should be 2)
    		var gt1 = t.GetData();
    		gt1 = gt1.Where(w => w.Id > 1);
    		Console.WriteLine("gt 1 count: {0}", gt1.Count());
    		
            // Here we're combining in a single statement, IsValid and gt 1 (should be 1)
    		var isValidAndIdGt1 = t.GetData();
    		isValidAndIdGt1 = isValidAndIdGt1.Where(w => w.IsValid && w.Id > 1);
    		Console.WriteLine("IsValid and gt 1 count: {0}", isValidAndIdGt1.Count());
    		
            // This is the same query as the one directly above, just broken up (could perhaps be some if logic in there to determine if to add the second Where
    		// Note this is how you're doing it in your question (and it's perfectly valid (should be 1)
    		var isValidAndIdGt1Appended = t.GetData();
    		isValidAndIdGt1Appended = isValidAndIdGt1Appended.Where(w => w.IsValid);
    		isValidAndIdGt1Appended = isValidAndIdGt1Appended.Where(w => w.Id > 1);
    		Console.WriteLine("IsValid and gt 1 count w/ appended where: {0}", isValidAndIdGt1Appended.Count());
            // This is the same query as the one directly above, but note we are executing the query twice
    		var isValidAndIdGt1AppendedTwice = t.GetData();
    		isValidAndIdGt1AppendedTwice = isValidAndIdGt1AppendedTwice.Where(w => w.IsValid);
			Console.WriteLine("IsValid and gt 1 count w/ appended where executing twice: {0}", isValidAndIdGt1AppendedTwice.Count()); // 2 results are valid
    		isValidAndIdGt1AppendedTwice = isValidAndIdGt1AppendedTwice.Where(w => w.Id > 1);
    		Console.WriteLine("IsValid and gt 1 count w/ appended where executing twice: {0}", isValidAndIdGt1AppendedTwice.Count()); // 1 result is both valid and id gt 1
			
            // This is one of the things you were asking about - note that without assigning the additional Where criteria to the Iqueryable, you do not get the results of the where clause, but the original query - in this case there are no appended where conditions on the t.GetData() call, so you get the full result set.
    		var notReallyValid = t.GetData();
    		notReallyValid.Where(w => w.Name == "this name definitly does not exist");
    		Console.WriteLine("where clause not correctly appended count: {0}", notReallyValid.Count());
		
    	}
    	
    }
    
    public class Thingy
    {
    	private List<Foo> _testData = new List<Foo>()
    	{
    		new Foo()
    		{
    			Id = 1,
    			Name = "Alpha",
    			Created = new DateTime(2015, 1, 1),
    			IsValid = true
    		},
    		new Foo()
    		{
    			Id = 2,
    			Name = "Beta",
    			Created = new DateTime(2015, 2, 1),
    			IsValid = false
    		},
    		new Foo()
    		{
    			Id = 3,
    			Name = "Gamma",
    			Created = new DateTime(2015, 3, 1),
    			IsValid = true
    		},			
    	};
    	
    	public IQueryable<Foo> GetData()
    	{
    		return _testData.AsQueryable();
    	}
    	
    	public void PrintData(IEnumerable<Foo> data)
    	{
    		// Note calling this will enumerate the data for IQueryable
    		foreach (Foo f in data)
    		{
    			Console.WriteLine(string.Format("id: {0}, name: {1}, created: {2}, isValid: {3}", f.Id, f.Name, f.Created, f.IsValid));
    		}
    	}
    }
    
    public class Foo
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public DateTime Created { get; set; }
    	public bool IsValid { get; set; }
    }
