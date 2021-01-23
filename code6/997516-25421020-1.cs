    // provide a flag 
    private bool ifLoadData = false;
    // set the flag before state is loaded
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        ifLoadData = e.NavigationMode == NavigationMode.Back;
        // rest of the code
    // then in LoadState just check if you want your data to be loaded
    private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
    {
        if (ifLoadData)
        {
           // load data
