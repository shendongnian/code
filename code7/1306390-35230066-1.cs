        private void MobileTheme_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as ToggleButton)?.IsChecked.Value == true)
            {
                ThemeSelector.ApplyTheme(new Uri("/MobileSkin.xaml", UriKind.Relative));
            }
            else
            {
                ThemeSelector.ApplyTheme(new Uri("/ClassicSkin.xaml", UriKind.Relative));
            }
        }
