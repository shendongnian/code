        private void LevelsPage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint currentPoint = e.GetCurrentPoint(this);
            if (currentPoint.PointerDevice.PointerDeviceType == PointerDeviceType.Mouse)
            {
                PointerPointProperties pointerProperties = currentPoint.Properties;
                if (pointerProperties.IsXButton1Pressed && this.Frame.CanGoBack)
                {
                    this.Frame.GoBack();                    
                }
                else if (pointerProperties.IsXButton2Pressed && this.Frame.CanGoForward)
                {
                    this.Frame.GoForward();
                }
            }
        }
