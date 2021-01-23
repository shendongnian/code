    private async void Form1_Load(object sender, EventArgs e)
    {
        Task t = Repopulate();
        // If you want to run its synchronous part on the thread pool:
        // Task t = Task.Run(() => Repopulate());
        // some other work here
        await t;
    }
    async Task Repopulate()
    {           
        var query = ParseObject.GetQuery("Offer");
        IEnumerable<ParseObject> results = await query.FindAsync();
        if (TitleList == null)
            TitleList = new List<string>();
        foreach (ParseObject po in results)
            TitleList.Add(po.Get<string>("title"));
    }
