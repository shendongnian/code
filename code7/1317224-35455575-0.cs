        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyBtn.Content = new Image
            {
                Source = new BitmapImage(new Uri("/Assets/chillr-uat (1).png", UriKind.RelativeOrAbsolute)),
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Fill,
                Height = 256,
                Width = 256
            };
        }
