    [HttpGet]
    public async Task<Items[]> Get()
    {
        Item item = null;
        List<Items> items = new List<Items>();
        do
        {
            item = DoRepitiousWork();
            Items.Add(item);
        }
        while (!Request.HttpContext.RequestAborted.IsCancellationRequested && !item.IsLast);
        return items.ToArray();
    }
