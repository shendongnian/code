      private void lstcheckbox_Checked_1(object sender, RoutedEventArgs e)
        {
            Data some = (sender as CheckEdit).DataContext as Data;
            if (some.Name.Contains("Others"))
            {
                some.Visible = ToggleVisibility(some.Visible);
            }
        }
        private Visibility ToggleVisibility(Visibility visibility)
        {
            return visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
