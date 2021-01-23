    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        int size = (int)e.Parameter; // Property, not method
        World world = new World(size); // Not clear to me what this is or does?
        myContent.Content = new CanvasWorld(size);
    }
