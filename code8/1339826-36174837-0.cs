    private Color c = Color.Blue; // Set default color
    
    private void btnRedClick(object sender, RoutedEventArgs e)
        {
           c = Color.Red;
        }
    
        private void inkCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inkCanvas.EditingMode == InkCanvasEditingMode.None)
            {
                if(dtm == DrawingToolMode.ellipse)
                {
                    Ellipse myEllipse = new Ellipse();
                    System.Windows.Media.SolidColorBrush scb =
                    new SolidColorBrush(c);
                    myEllipse.Stroke = (scb);
                    myEllipse.Fill = (scb);
                    Point p = Mouse.GetPosition(this.inkCanvas);
                    InkCanvas.SetTop(myEllipse, p.Y);
                    InkCanvas.SetLeft(myEllipse, p.X);
                    myEllipse.Height = 20;
                    myEllipse.Width = 20;
                    inkCanvas.Children.Add(myEllipse);
                }
            }
    
        }
