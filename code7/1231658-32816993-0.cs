    static void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
        {
            if (Keyboard.IsKeyDown(Key.A))
            {
                e.Handled = true;
            }
            if(Keyboard.IsKeyDown(Key.Z))
            {
                e.Handled = true;
            }
        }
    }
