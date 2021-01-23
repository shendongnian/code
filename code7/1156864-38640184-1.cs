    [HttpPost]
    public async Task<string> PostUpload()
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes("Test");
        var data = new VideoData { Data = bytes };
        CloudMediaContext _context;
        using (MemoryStream ms = new MemoryStream(data.Data))
        {
            var accountName = "accountName";
            var accountKey = @"primaryaccessKey";
            _context = new CloudMediaContext(accountName, accountKey);
            var asset = await _context.Assets.CreateAsync("myjblobassets", AssetCreationOptions.None, CancellationToken.None);
            //... do something with asset and ms ...
        }
        return "http://my-link";
    }
