      bool clicked = false;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var imageDirPath = $"{basePath}\\Images\\";
            if (clicked)
                image.Source = new BitmapImage(new Uri(imageDirPath+ "lobby.jpg"));
            else
                image.Source = new BitmapImage(new Uri(imageDirPath + "lobby1.jpg"));
            clicked = !clicked;
        }
