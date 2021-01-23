    private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        string selectedRect;
        if (e.OriginalSource is Rectangle)
        {
            Rectangle ClickedRectangle = (Rectangle)e.OriginalSource;
    
            var mouseWasDownOn = e.Source as FrameworkElement;
            string elementName = mouseWasDownOn.Name;
            selectedRect = elementName.ToString();
    
            //ViewModel code
            var vm = this.ViewModel as YourViewModel;
            vm.RectangleName = elementName.ToString();
        }
    }
