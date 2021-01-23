        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
    #if WINDOWS_PHONE_APP
            TextBox tb = sender as TextBox;
            if (!tb.IsReadOnly)
            {
                InputPane.GetForCurrentView().TryShow();
            }
    #endif
        }   
