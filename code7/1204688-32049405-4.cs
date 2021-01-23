    private void SWMTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            MoveCustomCaret();
            border.Visibility = Visibility.Visible;
        }
