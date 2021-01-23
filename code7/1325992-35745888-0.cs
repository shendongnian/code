            // rectangle 
            r.Width = 10;
            r.Height = 50;
            // rectangle Color
            r.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 255));
            // canvas 
            c.Children.Add(r);
            c.Width = 10;
            c.Height = 50;
            RotateTransform rt = new RotateTransform();
            rt.Angle=-68.962;
            c.RenderTransform = rt;
        }
