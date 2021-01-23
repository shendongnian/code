    PivotItem pivot = null;
        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplicationBar appBar = new ApplicationBar();
            ApplicationBarIconButton appBarIconButton = new ApplicationBarIconButton();
            pivot = (PivotItem)(sender as Pivot).SelectedItem;
            switch(pivot.Header.ToString())
            {
                case "item1": 
                    appBar.Mode = ApplicationBarMode.Default;
                    appBarIconButton.IconUri = new Uri("/appbar.close.png", UriKind.RelativeOrAbsolute);
                    appBarIconButton.Text = "Close";
                    appBar.Buttons.Add(appBarIconButton);
                    this.ApplicationBar = appBar;
                    break;
                case "item2":
                    appBar.Mode = ApplicationBarMode.Minimized; // To minimize AppBar
                    appBar = null; // Delete Application Bar                     
                    this.ApplicationBar = appBar;
                    break;
                case "item3":
                    appBar.Mode = ApplicationBarMode.Minimized;
                    appBar = null;                   
                    this.ApplicationBar = appBar;
                    break;
            }
        }
