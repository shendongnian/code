     private void myAdorner_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
            {
                MouseButtonEventArgs revent = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, MouseButton.Right);
                revent.RoutedEvent = e.RoutedEvent;
                //find you control
                control.RaiseEvent(revent);
            }
