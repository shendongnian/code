     private void ListBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
           If e.Keycode==keys.Enter
           {
             //do what you want
           }
           Else
           {
             e.Handled = true;
           }
         }
