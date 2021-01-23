    private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        if (e.OriginalSource == SearchBox)
        {
            pup.IsOpen = true;
        }
        else
        {
            pup.IsOpen = false;
        }
    }
