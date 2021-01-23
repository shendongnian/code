    void Chart_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseCaptured)
            {
                Point mouseDelta = Mouse.GetPosition(this);
                mouseDelta.Offset(-mouseOffset.X, -mouseOffset.Y);
                Margin = new Thickness(
                    Margin.Left + mouseDelta.X,
                    Margin.Top + mouseDelta.Y,
                    Margin.Right - mouseDelta.X,
                    Margin.Bottom - mouseDelta.Y);
            }
        }
        void Chart_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mouseOffset = Mouse.GetPosition(this);
            CaptureMouse();
            parent.currentObject = this;
        }
