    public async void SoneEventHandler(object sender, EventArgs e)
    {
        foreach (var item in items)
        {
            var result = await Task.Run(() => DoWork());
            // Update UI
        }
    }
