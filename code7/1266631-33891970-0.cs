    private void Button_Click(object sender, RoutedEventArgs e)
        {
            Border b = (Border)this.Template.FindName("BORDERCONTROL", this);
            b.Background = new SolidColorBrush(Colors.Yellow);
        }
