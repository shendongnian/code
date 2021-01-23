    public async Task LongPoll(Uri remoteEndPoint)
    {
    	for(;;)
    	{
    		string data;
    		using(var wc=new WebClient())
    		{
    			data = await wc.DownloadStringTaskAsync(remoteEndPoint);
    		}
    		Process(data);	
    	}
    }
