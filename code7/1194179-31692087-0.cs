    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		List<Test> tests = new List<Test>
    		{
    			new Test() { Id = 6, ParentId = 2, HasParentObject = true },
    			new Test() { Id = 2, ParentId = 0, HasParentObject = false },
    			new Test() { Id = 1, ParentId = 0, HasParentObject = true },
    			new Test() { Id = 4, ParentId = 1, HasParentObject = true }
    		};
    		
    		// Get the parents sorted
    		List<Test> sortedTests = tests.Where(t => tests.FindIndex(t2 => t2.ParentId == t.Id) != -1)
    			.OrderBy(t => t.Id)
    			.ToList();
    		
    		// Add those that aren't parents sorted
    		sortedTests.AddRange(tests.Where(t => tests.FindIndex(t2 => t2.ParentId == t.Id) == -1)
    			.OrderBy(t => t.Id));
    		sortedTests.ForEach(t => Console.WriteLine("ID: {0} ParentId: {1}", t.Id, t.ParentId));
    	}
    }
    
    class Test
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public bool HasParentObject { get; set; }
    }
