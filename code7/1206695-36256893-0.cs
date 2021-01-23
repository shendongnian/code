    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            this.AdMediator_ECB2E3.Disable();
            base.OnNavigatingFrom(e);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.AdMediator_ECB2E3.Resume();
            base.OnNavigatedTo(e);
        }
