    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
         if (Keyboard.IsKeyDown(Key.Enter) && Keyboard.Modifiers == ModifierKeys.None)
            {
                    MessageBox.Show("Enter Pressed");
            }
    }
