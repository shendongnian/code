    private void gridContainer_Tapped(object sender, TappedRoutedEventArgs e)
    {
       if(e.OriginalSource is FrameworkElement)
       {
          var col = Grid.GetColumn(e.OriginalSource as FrameworkElement);
       }
    }
