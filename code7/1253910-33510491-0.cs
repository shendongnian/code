    public class JobListing
    {
    	public int Id { get; set;}
    	public string Name { get; set; }
    	public List<Job> Jobs { get; set; }
    }
    
    public class Job
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public string Action { get; set; }
    }
    
    public List<Job> CreateJobs()
    {
    	return new List<Job>
    	{
    		new Job { Id = 1, Name = "First", Action = "Does It"},
    		new Job { Id = 2, Name = "Second", Action = "Does It Again"},
    		new Job { Id = 3, Name = "Third", Action = "Does It Yet Again"},
    	};
    }
    
    public List<JobListing> CreateJobListings()
    {
    	return new List<JobListing>
    	{
    		new JobListing { Id = 1, Name = "First Area", Jobs = CreateJobs() },
    		new JobListing { Id = 2, Name = "Second Area", Jobs = CreateJobs() },
    	};
    }
    
    void Main()
    {
    	var jobslistings = CreateJobListings();
    
    	jobslistings.ForEach(x => {
    	//x => is a lambda statement and I am using Fluent Syntax off of a method that returns my containers.
    	//x is now each object in my collection.  In this case it is a 'JobListing' object POCO I Made.
    		Console.WriteLine(string.Format("{0} {1}", x.Id, x.Name));
    		Console.WriteLine("\tJobs");
    		x.Jobs.ForEach(y => {
    		// y => is a lambda statement and I am now in an object of an object.
    			Console.WriteLine(string.Format("\t\t{0} {1}", y.Id, y.Name));	
    		});
    	});
    	
    	Console.WriteLine();
    	Console.WriteLine("Where Clause");
    	Console.WriteLine();
    	
    	jobslistings.Where(predicate => predicate.Id == 1).ToList().ForEach(x => {
    	//x => is a lambda statement and I am using Fluent Syntax off of a method that returns my containers.
    	//x is now each object in my collection.  In this case it is a 'JobListing' object POCO I Made.
    		Console.WriteLine(string.Format("{0} {1}", x.Id, x.Name));
    		Console.WriteLine("\tJobs");
    		x.Jobs.ForEach(y => {
    		// y => is a lambda statement and I am now in an object of an object.
    			Console.WriteLine(string.Format("\t\t{0} {1}", y.Id, y.Name));	
    		});
    	});
    }
