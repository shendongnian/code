    // Keep track of the Canvas where this element is placed.
            private Canvas canvas;
            // Keep track of when the element is being dragged.
            private bool isDragging = false;
            // When the element is clicked, record the exact position
            // where the click is made.
            private Point mouseOffset;
            private void control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                // Find the Canvas.
                if (canvas == null)
                    canvas = (Canvas)VisualTreeHelper.GetParent(this.Label);
                // Dragging mode begins.
                isDragging = true;
                // Get the position of the click relative to the element
                // (so the top-left corner of the element is (0,0).
                mouseOffset = e.GetPosition(this.Label);
                // Capture the mouse. This way you'll keep receiving
                // the MouseMove event even if the user jerks the mouse
                // off the element.
                this.Label.CaptureMouse();
            }
    
            private void control_MouseMove(object sender, MouseEventArgs e)
            {
                if (isDragging)
                {
                    // Get the position of the element relative to the Canvas.
                    Point point = e.GetPosition(canvas);
                    // Move the element.
                    this.Label.SetValue(Canvas.TopProperty, point.Y - mouseOffset.Y);
                    this.Label.SetValue(Canvas.LeftProperty, point.X - mouseOffset.X);
                }
            }
    
            private void control_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                if (isDragging)
                {
                    this.Label.ReleaseMouseCapture();
                    isDragging = false;
                }
            }
