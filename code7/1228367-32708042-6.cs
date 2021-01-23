    public async Task<List<Transaction>> TransactionsGrid()
    {
    	if (transactionsGrid == null)
    	{
    		var client = new System.Net.Http.HttpClient(new ModernHttpClient.NativeMessageHandler());
    		client.BaseAddress = new Uri("http://theWebAddress.com/);
    		var response = await client.GetAsync("API.svc/Transactions/" + accountId + "/" + fromDate.ToString("yyyy-MM-dd") + "/" + toDate.ToString("yyyy-MM-dd"));
    		var transactionJson = await response.Content.ReadAsStringAsync(); //DONT USE Result HERE, USE AWAIT AS PER @Noseratio suggested
    		var transactions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Transaction>>(transactionJson);
    		transactionsGrid = transactions;
    	}
    		return transactionsGrid;
    }
