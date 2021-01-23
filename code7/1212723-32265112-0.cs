    private void OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            e.Handled = true;
            if (sender is TextBox)
            {
                var _parentWindow = Window.GetWindow((UIElement)sender);
                if (!_parentWindow.IsLoaded)
                {
                    this.IsOpen = false;
                    _parentWindow.ContentRendered += (o, i) => this.IsOpen = true;
                }
                else
                {
                    this.IsOpen = true;
                }
            }
            else
            {
                this.IsOpen = false;
            }
        }
