    public class MyToggleButton : ToggleButton
    {
        protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
            {
                IsChecked = true;
                base.OnGotKeyboardFocus(e);
            }
        }
        protected override void OnLostFocus(System.Windows.RoutedEventArgs e)
        {
            IsChecked = false;
            base.OnLostFocus(e);
        }
    }
