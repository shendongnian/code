    [TestClass()]
    public class JobTests
    {
    	private Service service;
    
    	[TestInitialize]
    	public void init()
    	{
    		service = new EmergencyService();
    	}
    
    	[TestMethod()]
    	// add one hour of service at $75/50 rate
    	public void Job_OnFullCost_Is75()
    	{
    		// Arrange
    		AddHourOfService(75, 50);
    
    		// Act
    		var expected = 75.0M;
    		var actual = service.JobCost;
    
    		// Assert
    		Assert.AreEqual(expected, actual);
    	}
    
    	[TestMethod()]
    	// add another hour to the service, at same rate of $175/60
    	public void Job_OnFullCost_Is125()
    	{
    		// Arrange
    		AddHourOfService(75, 50);
    		AddHourOfService(75, 50);
    		
    		// Act
    		var expected = 125.0M;
    		var actual = service.JobCost;
    
    		// Assert
    		Assert.AreEqual(expected, actual);
    	}
    
    	private void AddHourOfService(int cost, int time)
    	{
    		var laborTime = new LaborTime(
    		checkIn: new DateTime(year: 2016, month: 7, day: 20, hour: 10, minute: 0, second: 0),
    		checkOut: new DateTime(year: 2016, month: 7, day: 20, hour: 11, minute: 0, second: 0)
    	);
    		var laborRates = new LaborRates(75, 50);
    		service = new Labor(service, laborTime, laborRates);
    	}
    }
