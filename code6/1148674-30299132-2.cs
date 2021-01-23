    public class Report
    {
    	public int ReportId { get; set; }
    	public string Title { get; set; }
    }
    
    public class TestCase
    {
    	public int TestId { get; set; }
    	public string Title { get; set; }
    }
    
    public class TestRun
    {
    	public int TestId { get; set; }
    	public int ReportId { get; set; }
    }
	var temp = from c in testCases
			   join ru in testRuns
			   on c.TestId equals ru.TestId into left
			   from l in left.DefaultIfEmpty(new TestRun())
			   join re in reports 
			   on l.ReportId equals re.ReportId into foo
			   from f in foo.DefaultIfEmpty()
			   select new {
			   		Test = c.Title,
					Report = f 
			   };
			   
	temp.Dump();
