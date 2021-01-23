	public void TestAllParallel()
    {
	//...
	System.Threading.Tasks.Parallel.Invoke(testActions);
	if(_allPassed){
		Assert.IsTrue(true, "All tests Passed:\n"+threadSafeStringBuilder.ToString());
		}else{
		Assert.Fail("Some tests failed:\n"+threadSafeStringBuilder.ToString());
		}
		
	)
	
