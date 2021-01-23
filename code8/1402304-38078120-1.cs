    private const int MAX_PARALLELISM = 20
    public async Task <List<Details>> Get()
    {
        var block = new ActionBlock<Entry>(async (c) => 
            {
                ResourceAccountListInfo resourceAccountListInfo = new ResourceAccountListInfo();
                using (WebClient wc = new WebClient()) 
                {
                    string url = currentURL + "resources/" + c.RESOURCEID + "/accounts?AUTHTOKEN=" + pmtoken;
                    string tempurl = url.Trim();
        
                    var json =  await wc.DownloadStringTaskAsync(tempurl);
                    resourceAccountListInfo = JsonConvert.DeserializeObject<ResourceAccountListInfo>(json);
                }
                //code goes here
            }
            ,new ExecutionDataflowBlockOptions 
                       { 
                             MaxDegreeOfParallelism = MAX_PARALLELISM,
                             BoundedCapacity = MAX_PARALLELISM * 4
                       });
    
        foreach(var entry in resourcesinfo.operation.Details)
        {
            await block.SendAsync(entry);
        }
        block.Complete();
        await block.Completion;
        //More code here    
    }
