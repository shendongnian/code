       private void ChangeThemeToLightClick(object sender, RoutedEventArgs e)
        {
            (Window.Current.Content as ThemeAwareFrame).AppTheme = ElementTheme.Light;
        }
        private void ChangeThemeToDarkClick(object sender, RoutedEventArgs e)
        {
            (Window.Current.Content as ThemeAwareFrame).AppTheme = ElementTheme.Dark;
        }
  
