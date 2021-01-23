    // This event occurs after the KeyDown event and can be used to prevent
    // characters from entering the control.
    private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        // Check for the condition
        if (SOME CONDITION)
        {
            // Stop the character from being entered into the control.
            e.Handled = true;
        }
    }
