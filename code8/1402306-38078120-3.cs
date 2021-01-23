    private const int MAX_PARALLELISM = 20
    public async Task<List<Details>> Get()
    {
        List<Details> result = new List<Details>();
        var getRecordBlock = new TransformBlock<Entry, ResourceAccountListInfo>(async (c) =>
            {
                ResourceAccountListInfo resourceAccountListInfo = new ResourceAccountListInfo();
                using (WebClient wc = new WebClient())
                {
                    string url = currentURL + "resources/" + c.RESOURCEID + "/accounts?AUTHTOKEN=" + pmtoken;
                    string tempurl = url.Trim();
                    var json = await wc.DownloadStringTaskAsync(tempurl);
                    resourceAccountListInfo = JsonConvert.DeserializeObject<ResourceAccountListInfo>(json);
                }
                return resourceAccountListInfo;
            }
            , new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = MAX_PARALLELISM,
                BoundedCapacity = MAX_PARALLELISM * 4
            });
        //Defaults to MaxDegreeOfParallelism = 1
        var addToListBlock = new ActionBlock<ResourceAccountListInfo>(info =>
        {
            Details detail = TurnResourceAccountListInfoInToDetails(info);
            result.Add(detail);
        });
        getRecordBlock.LinkTo(addToListBlock, new DataflowLinkOptions { PropagateCompletion = true});
        foreach (var entry in resourcesinfo.operation.Details)
        {
            await getRecordBlock.SendAsync(entry);
        }
        getRecordBlock.Complete();
        await addToListBlock.Completion;
        return result;
    }
