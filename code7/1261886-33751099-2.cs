    private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            canvas.CaptureMouse();
        }
        Stopwatch sw = new Stopwatch();
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (canvas.IsMouseCaptured)
            {
                translate.X = e.GetPosition(container).X;
                translate.Y = e.GetPosition(container).Y;
            }
        }
        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            canvas.ReleaseMouseCapture();
        }
