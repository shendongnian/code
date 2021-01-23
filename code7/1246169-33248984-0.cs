    public async Task GreetAllAsync(List<string> UserNames)
    {
      var tasks = UserNames
      	.Select(un => GreetAsync(un)
    		.ContinueWith(x => {
      			Console.WriteLine(un + " has been greeted");
      		}));
    
    	await Task.WhenAll(tasks);
    }
