    private bool _isTransparent = false;
    private int _extendedStyle;
    private void toggleTransparencyButton_Click(object sender, RoutedEventArgs e)
    {
        HwndSource popupHwndSource = HwndSource.FromVisual(rectangle) as HwndSource;
        if (_isTransparent == false)
        {
            _extendedStyle = WindowsServices.SetWindowExTransparent(popupHwndSource.Handle);
            _isTransparent = true;
        }
        else
        {
            WindowsServices.UndoWindowExTransparent(popupHwndSource.Handle, _extendedStyle);
            _isTransparent = false;
        }
    }
