    private void MouseEnter(object sender, MouseEventArgs e)
    {
        var mouseWasDownOn = e.Source as FrameworkElement;
        if (mouseWasDownOn != null)
        {
            string elementName = mouseWasDownOn.Name;
            ((Path)mouseWasDownOn).Fill = new SolidColorBrush(Color.FromArgb(255, 193, 194, 194));     
        }
    }
