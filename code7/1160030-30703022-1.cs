    public async Task DoStuff()
    {
        using(var client = ApiService.GetClient())
        {
            //client will have the proper base uri and all the headers set.
            var data = await client.GetAsync<dynamic>("Sales");
            //client will still have the proper base uri and all the headers set.
            var data2 = await client.GetAsync<dynamic>("Products");
        }
    }
