     private void MyCanvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            p2 = e.GetPosition(MyCanvas);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (p1.X < p2.X)
                    Canvas.SetLeft(Myline, p1.X);  else Canvas.SetLeft(Myline, p2.X);
                if (p1.Y < p2.Y)
                    Canvas.SetTop(Myline, p1.Y);  else Canvas.SetTop(Myline, p2.Y);
                Myline.Width = Math.Max(p2.X, p1.X) - Math.Min(p2.X, p1.X);
                Myline.Height = Math.Max(p2.Y, p1.Y) - Math.Min(p2.Y, p1.Y);
           }
        }
