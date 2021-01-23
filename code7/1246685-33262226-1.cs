        public async Task<Data> MakeWebRequest(string resource)
	    {
            ...
	    }
	    public async Task<DataCollected> CollectData()
	    {
	        var result = new DataCollected();
	        var task1 = MakeWebRequest("/data/x");
	        var task2 = MakeWebRequest("/data/y");
	        var task3 = MakeWebRequest("/data/z");
	        await Task.WhenAll(task1, task2, task3);
	        result.data1 = task1.Result;
	        result.data2 = task2.Result;
	        result.data3 = task3.Result;
	        return result;
	    }
