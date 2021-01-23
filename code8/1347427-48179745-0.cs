        private Grid RootGrid => (Grid)Window.Current.Content;
        private Frame Frame => this.RootGrid?.Children[0] as Frame;
        private ContentDialog ContentDialog => this.RootGrid?.Children[1] as ContentDialog;
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (Window.Current.Content == null) {
                Window.Current.Content = new Grid();
                Debug.Assert( this.RootGrid != null);
                this.RootGrid.Children.Add(new Frame()); 
                this.RootGrid.Children.Add(new ContentDialog());
                Debug.Assert(this.Frame != null && this.ContentDialog != null);
            }
            ...
            Window.Current.Activate();
        }
