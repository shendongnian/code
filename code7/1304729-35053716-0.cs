            Point p = new Point();
            private void ellipse_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
            {
                ellipse.CaptureMouse();
    
                p.X = e.GetPosition(canvas).X - Canvas.GetLeft(ellipse);
                p.Y = e.GetPosition(canvas).Y - Canvas.GetTop(ellipse);
    
                Debug.WriteLine(p.X + " : " + p.Y);            
            }
    
            private void canvas_MouseMove_1(object sender, MouseEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    var e_point = e.GetPosition(canvas);
    
                    Debug.WriteLine(e_point.X + " : " + p.X);
    
                    Canvas.SetLeft(ellipse, e_point.X - p.X);
                    Canvas.SetTop(ellipse, e_point.Y - p.Y);
                }
            }
    
            private void ellipse_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
            {
                ellipse.ReleaseMouseCapture();
            }
