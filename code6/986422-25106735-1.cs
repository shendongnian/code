        private void TextBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Slider != null)
            {
                TextBox.Width = Slider.Value;
            }
        }
