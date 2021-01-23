    public static void GetResponse<TDataContract>(Uri uri, Action<TDataContract> callback)
    			where TDataContract : IDataContract, class, new()
    {
    	var contract = new TDataContract();
    	var contractType = contract.GetType();
    
    	var wc = new System.Net.WebClient();
    	wc.OpenReadCompleted += (o, a) =>
    	{
    		if (callback != null)
    		{
    			var ser = new DataContractJsonSerializer(typeof(TDataContract));
    			var obj = ser.ReadObject(a.Result);
    			callback((TDataContract)obj);
    		}
    	};
    
    	wc.OpenReadAsync(uri);
    }
