    private Point startPoint;
    private void btnChat_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                startPoint = e.GetPosition(btnChat);
            }
    
            private void btnChat_PreviewMouseMove(object sender, MouseEventArgs e)
            {
                var currentPoint = e.GetPosition(btnChat);
                if (e.LeftButton == MouseButtonState.Pressed &&
                    btnChat.IsMouseCaptured &&
                    (Math.Abs(currentPoint.X - startPoint.X) >
                        SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(currentPoint.Y - startPoint.Y) >
                        SystemParameters.MinimumVerticalDragDistance))
                {
                    // Prevent Click from firing
                    btnChat.ReleaseMouseCapture();
                    DragMove();
                }
            }
