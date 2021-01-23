    private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                additem_button.Command.Execute("");
                e.Handled = true;
            }
        }
    // button.Command.Execute("your parameter"); because on my button, the
    // command has been binded to a Delegate Command inside the VM :D
