            private void Button_Click_1(object sender, RoutedEventArgs e)
               {
                Button button = sender as Button;
                button.Content = new Image
                {
                    Source = new BitmapImage(new Uri("/Images/imagename.JPG", UriKind.RelativeOrAbsolute)),
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.Fill,
                    Height = 256,
                    Width = 256
                };
              }
