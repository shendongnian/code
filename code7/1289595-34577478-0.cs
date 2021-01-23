    private void textBox1_KeyPress
    (object sender,System.Windows.Forms.KeyPressEventArgs e)
    {
        // Check for the flag being set in the KeyDown event.
        if (nonNumberEntered == true)
        {
            e.Handled = true;
        }
    }
