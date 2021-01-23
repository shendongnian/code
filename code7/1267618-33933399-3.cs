     public async Task AddWorkItem()
            {
                using (var client = HttpClientFactory.GetClient())
                {
                    //Complex object example::
                    ///////////////////
                    var item = new WorkItem()
                    {
                        Description = DateTime.Now.ToString("h:mm:ss tt"),
                        Id = 11
                    };
    
                    var inner1 = new ItemUsage()
                    {
                        Id = 45,
                        UsedFor = "something"
                    };
    
                    Collection<ItemUsage> Usage = new Collection<ItemUsage>();
                    Usage.Add(inner1);
    
                    item.Usage = Usage;
                    ////////////////////////////
                    var json = JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                    var response = await client.PostAsync("api/WorkItem", content);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception((int)response.StatusCode + "-" + response.StatusCode.ToString());
                    }
                }
           }
