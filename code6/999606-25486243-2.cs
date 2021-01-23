    private DispatcherTimer _searchTimer;
    // Initialize timer in constructor with 200 ms delay and register tick event.
    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        _searchTimer.Stop();
        _searchTimer.Start();
    }
    
    private void OnSearchTimerTick(object sender, EventArgs e)
    {
        _searchTimer.Stop()
        Search(searchBox.Text);
    }
    
    private void Search(string searchTxt)
    {
        // Do search
    }
