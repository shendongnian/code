        public void DisplayNumber(int i) {
            MessageBox.Show("Rectangle No. " + i);
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
                Can1.Children.Add(RectangleArray[i]);
                RectangleArray[i].MouseLeftButtonDown += (sender2, e2) => DisplayNumber(index+1);
            }
        }
