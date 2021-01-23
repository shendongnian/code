        private void RegisterToDigitFocusEvents(int index, TextBox digit)
        {
            RoutedEventHandler gotFocusHandler = (s, e) =>
            {
                try
                {
                    this.ResetDigit(digit, index)
                }
                catch (Exception error)
                {
                    this.Log().Error("Observing digit GotFocus", error);
                }
            };
            digit.GotFocus += gotFocusHandler;
        }
