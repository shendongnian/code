    private void Selected_Color_Changed(object sender, RoutedPropertyChangedEventArgs<Color?> e)
    {
        YourRichTextControlElement.Focus();
        Xceed.Wpf.Toolkit.ColorPicker colorPicker = sender as Xceed.Wpf.Toolkit.ColorPicker;
        colorPicker.IsOpen = false;
     }
