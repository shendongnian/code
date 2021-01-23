    private async void Form1_Load(object sender, EventArgs e)
    {
        Task t = Repopulate();
        // some other work here
        t.Wait(); //completes prematurely
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
