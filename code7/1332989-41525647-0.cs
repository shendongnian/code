        private void handleMouseMoveEvent(object sender, MouseEventArgs args)
        {
            if (args.LeftButton == MouseButtonState.Pressed)
            {
                Point parentPosition = Mouse.GetPosition(parentCanvas);   
             
                Canvas.SetLeft(this, (parentPosition.X - Width / 2));
                Canvas.SetTop(this, (parentPosition.Y - Height / 2));                
            }
            
            args.Handled = true;
         }
