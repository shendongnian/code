    public class Worker 
    {
    	public string Name {get;set;}
    	public string CompanyId {get;set;}
    	public string CompanyName {get;set;}
    }
    
    public class Company
    {
     public string Name {get;set;}
     public string Id {get;set;}
    }
       var companyList = new List<Company>
		{
			new Company{Id = "1", Name = "Company 1"},
	        new Company{Id = "2", Name = "Company 2"},
			new Company{Id = "3", Name = "Company 3"}
		};
		
		var workerList = new List<Worker>
		{
			new Worker{ Name = "Worker 1", CompanyId = "2" },
	        new Worker{ Name = "Worker 2", CompanyId = "1" },
			new Worker{ Name = "Worker 3", CompanyId = "2" },
			new Worker{ Name = "Worker 4", CompanyId = "3" },
			new Worker{ Name = "Worker 5", CompanyId = "1" }
		};
    workerList.ForEach(w => {
    			w.CompanyName = companyList.FirstOrDefault(c=>c.Id == w.CompanyId).Name;
    		});
		
		
	foreach(var w in workerList)
	{
		Console.WriteLine(w.Name+"-"+w.CompanyName);
		// ==> output will be
		//Worker 1-Company 2
        //Worker 2-Company 1
		//Worker 3-Company 2
		//Worker 4-Company 3
		//Worker 5-Company 1
	}
