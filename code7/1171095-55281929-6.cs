    //Change BoundedCapacity to +1 to see it fail
	[TestMethod]
	public void stackOverflow()
	{      
		var total = 1000;
		var processed = 0;
		var block = new ActionBlock<int>(
		   (messageUnit) =>
		   {
			   Thread.Sleep(10);
			   Trace.WriteLine($"{messageUnit}");
			   processed++;
		   },
			new ExecutionDataflowBlockOptions() { BoundedCapacity = -1 } 
	   );
		for (int i = 0; i < total; i++)
		{
			var result = block.SendAsync(i);
			Assert.IsTrue(result.IsCompleted, $"failed for {i}");
		}
		block.Complete();
		block.Completion.Wait();
		Assert.AreEqual(total, processed);
	}
	
