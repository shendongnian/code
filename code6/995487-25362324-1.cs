    public async Task TestServerLoad()
    {
       var firstTaskCall = DoSomeAsyncOperation();
	   await Task.Delay(1000); // Lets assume it takes about a second to execute work agains't the server
	   var secondCall = DoSomeAsyncOperation();
	   await Task.WhenAll(firstTaskCall, secondCall); // Wait till both complete
    }
