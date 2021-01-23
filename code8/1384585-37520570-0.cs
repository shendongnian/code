    private void Shape1Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var senderButton = sender as Button;
        if (senderButton.Tag is Color) {
           senderButton.Background = (Color)senderButton.Tag; // maybe make SolidColorBrush from color instead, here
           senderButton.Tag = null;
        } else {
          Color selectedColor = (Color)(Shape1Color.SelectedItem as PropertyInfo).GetValue(null, null);
          senderButton.Tag = selectedColor;
        }
    }
