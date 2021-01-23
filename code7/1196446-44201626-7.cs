    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             SplitView sv = new SplitView();
             sv = e.Parameter as NavigateControls;
        }
