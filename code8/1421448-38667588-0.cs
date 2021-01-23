    // This event occurs after the KeyDown event and can be used to prevent
    // characters from entering the control.
    private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        // Check for the flag being set in the KeyDown event.
        if (e.KeyCode == Keys.Enter)
        {
            // Stop the character from being entered into the control since it is non-numerical.
            MessageBox.Show("Enter Was Pressed");
            e.Handled = true;
        }
    }
