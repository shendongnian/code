    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
         if ((bool)(sender as ToggleButton).IsChecked)
         {
              Play(); // Call Play method
         }
         else
         {
              Stop(); // Call Stop method
         }
    }
