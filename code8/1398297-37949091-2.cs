    [Fact]
    public void Test_My_Method()
    {
    	IMyService service = new MyService(...);
    	var result = await service.MyMethodToTest("");
    	Task task = service.MyMethodToTest("")
    		   .ContinueWith(innerTask =>
    		   {
    			   var result = innerTask.Result;
    			   // ... assertions here ...
    		   });
    
    	task.Wait();
    }
