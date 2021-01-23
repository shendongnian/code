    public void cardstack_Holding(object sender, HoldingRoutedEventArgs e)
        {
            option_menu.ShowAt(sender as FrameworkElement);
            e.Handled = true;
        }
    private void cardstack_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Pointer pointr = e.Pointer;
            if (pointr.PointerDeviceType ==  Windows.Devices.Input.PointerDeviceType.Mouse)
            {
                Windows.UI.Input.PointerPoint pointrd = e.GetCurrentPoint(sender as UIElement);
                if (pointrd.Properties.IsRightButtonPressed)
                {
                    option_menu.ShowAt(sender as FrameworkElement);
                }
            }
            e.Handled = true;
        }
