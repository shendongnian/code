    private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                additem_button.Focus(FocusState.Pointer);
            }
        }
    //FocusState.Pointer as if the button was clicked by the user..
