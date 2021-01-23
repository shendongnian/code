    [HttpGet]
    public async Task<JsonResult> Update() //notice async in this line and I have changed the return type
    {
    	try
    	{
    		var id = 0;
            //Create random data
    		StudentViewModel[] studentData = new StudentViewModel[] {
    		new StudentViewModel { ID = id++ }, new StudentViewModel { ID = id++ }, new StudentViewModel { ID = id++ }, new StudentViewModel { ID = id++ },
    		new StudentViewModel { ID = id++ }, new StudentViewModel { ID = id++ }, new StudentViewModel { ID = id++ }, new StudentViewModel { ID = id++ },
    		new StudentViewModel { ID = id++ }, new StudentViewModel { ID = id++ }, new StudentViewModel { ID = id++ }, new StudentViewModel { ID = id++ }
    		};
    		IEnumerable<Task> tasksQuery = studentData.Select(s => UpdateStudentData(s)); //Note there is no async and await in this line
    
    		List<Task> tasks = tasksQuery.ToList();
    
    		await Task.WhenAll(tasks); //Note await here
    
    		return Json(new { success = true });
    	}
    	catch (Exception ex)
    	{
    		//log.Warn(string.Format("{0}: {1}", "Operation Failed", ex.ToString()));
    		return Json(new { success = false });
    	}
    }
    
    private async Task UpdateStudentData(StudentViewModel sm)
    {
    	await Task.Run(() =>
    	{
    		var sleepDelay = new Random().Next(500, 1000);
    		Task.Delay(sleepDelay); //Add random sleep to prove that students are not processsesd in a sequence
    		Debug.WriteLine($"ID: {sm.ID}, SleepDelay: {sleepDelay}");
    	});			
    }
    public class StudentViewModel
    {
    	public int ID { get; internal set; }
    }
