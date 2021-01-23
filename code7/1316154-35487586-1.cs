        private void ClickEvent(object sender, EventArgs e, int i) {
            var time = DateTime.Now;
            Console.WriteLine("Rectangle click at " + time + " from Rect. Nr." + i);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            int NumObjects = 10;
            Rectangle[] RectangleArray = new Rectangle[NumObjects];
            for (int i = 0; i < NumObjects - 1; i++) {
                int index = i;
                RectangleArray[i] = new Rectangle();
                RectangleArray[i].Width = 50;
                RectangleArray[i].Height = 50;
                RectangleArray[i].Fill = Brushes.Red;
                Canvas.SetTop(RectangleArray[i], i * 50);
                Canvas.SetLeft(RectangleArray[i], i * 50);
                RectangleArray[i].MouseLeftButtonDown += (sender2, e2) => ClickEvent(sender2, e2, index);
                Canvas1.Children.Add(RectangleArray[i]);
            }
        }
