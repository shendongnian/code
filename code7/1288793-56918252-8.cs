      /// <summary>
      /// Switch the app's theme between light mode and dark mode, and save that setting.
      /// </summary>
      private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
      {
         FrameworkElement window = (FrameworkElement)Window.Current.Content;
         if (((ToggleSwitch)sender).IsOn)
         {
            AppSettings.Theme = AppSettings.NONDEFLTHEME;
            window.RequestedTheme = AppSettings.NONDEFLTHEME;
         }
         else
         {
            AppSettings.Theme = AppSettings.DEFAULTTHEME;
            window.RequestedTheme = AppSettings.DEFAULTTHEME;
         }
      }
