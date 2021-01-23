    var policy = Policy.Handle<Exception>()
    // Retry 5 times waiting 1 second in between
					.WaitAndRetry(5, x => TimeSpan.FromSeconds(1), (e,d,c) =>
					{					
						Console.WriteLine("Count = {0}, Message = {1}", c.Count, e.Message);
					});	
					
	policy.Execute(() => 
	{
	   throw new Exception("Error!");
	});
