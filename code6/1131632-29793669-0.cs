    await Task.WhenAll(someList.Select(async i =>
    {
        var button = new Button();
        // Modify some button attributes height,width etc
        using (var wc = new WebClient())
        using (var stream = new MemoryStream(await wc.DownloadDataTaskAsync(current.thumbnail)))
        {
            button.BackgroundImage = Image.FromStream(stream);
        }
        // and then i have these UI components that need updating (imagePanel is a FlowLayoutPanel)
        imagePanel.Controls.Add(button);
        imagePanel.Refresh();
        progBar.PerformStep();
    }));
