    public class MyWindowBase : Window
        {
            private ContentControl contentControl;
    
            public MyWindowBase()
            {
                this.CreateContent();
            }
    
            public Object BaseContent
            {
                get { return this.contentControl.Content; }
                set { this.contentControl.Content = value; }
            }
    
            private void CreateContent()
            {
                var grid = new Grid();
                var row1 = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
                var row2 = new RowDefinition() { Height = GridLength.Auto };
                grid.RowDefinitions.Add(row1);
                grid.RowDefinitions.Add(row2);
    
                var statusBar = new StatusBar() { Height = 35, Background = Brushes.Blue }; // Initialize the status bar how you want.
                Grid.SetRow(statusBar, 1);
    
                this.contentControl = new ContentControl();
    
                grid.Children.Add(this.contentControl);
                grid.Children.Add(statusBar);
    
                base.Content = grid;
            }
        }
