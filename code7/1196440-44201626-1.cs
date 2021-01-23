    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             SplitView sp = new SplitView();
             sp = e.Parameter as NavigateControls;
        }
