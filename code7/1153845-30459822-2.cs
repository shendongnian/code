        private async void b1_Click(object sender, RoutedEventArgs e)
        {
            CanvasContainer.Children.Clear();
            _images = new List<Image>();
            // load bitmap
            BitmapImage bmp = new BitmapImage(new Uri("Assets/appbar/appbar.italic.png", UriKind.Relative));
            // create 20 Image instance
            for (int i = 0; i < 20; i++)
            {
                Image img = new Image();
                img.Source = bmp;
                img.Stretch = Stretch.Fill;
                img.Width = 20;
                img.Height = 20;
                
                _images.Add(img);
                Canvas.SetTop(img, 0);
                Canvas.SetLeft(img, i * 20 + 5);
                CanvasContainer.Children.Add(img);
            }
            // Simulate some delay or any task (3 sec)
            await Task.Delay(3000); 
            Storyboard sb = new Storyboard();
            // delay animation time for each object
            TimeSpan beginTime = TimeSpan.FromMilliseconds(0);
            foreach (Image img in _images)
            {
                DoubleAnimation da = new DoubleAnimation();
                da.From = 0; // Set start value to 0 px
                da.To = 700; // Set end value to 700 px
                da.Duration = new Duration(TimeSpan.FromSeconds(2)); // Set animation time to 2 sec
                da.BeginTime = beginTime; // Set delay for each Image
                beginTime += TimeSpan.FromMilliseconds(100);
                Storyboard.SetTarget(da, img);
                Storyboard.SetTargetProperty(da, new PropertyPath("(Canvas.Top)"));
                sb.Children.Add(da);
            }
            sb.Begin();
        }
