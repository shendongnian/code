    public async void SoneEventHandler(object sender, EventArgs e)
    {
        var result = await Task.Run(() => items.Select(item => DoWork()).ToList());
        foreach (var item in items)
        {
            // Update UI
        }
    }
