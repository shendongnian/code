        mediaElement.TransportControls.DoubleTapped += TransportControls_DoubleTapped;
        private void TransportControls_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            mediaElement.IsFullWindow = !mediaElement.IsFullWindow;
        }
