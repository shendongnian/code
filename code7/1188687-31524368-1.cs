    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        //Only change the digit if there is no selection
        if (textBox.SelectionLength == 0)
        {
            //Save the current caret position to restore it later
            int selStart = textBox.SelectionStart;
            //These next few lines determines how much to add or subtract
            //from the value based on the caret position in the number.
            int box_int = 0;
            Int32.TryParse(textBox.Text, out box_int);
            int powerOf10 = textBox.Text.Length - textBox.SelectionStart - 1;
            //If the number is negative, the SelectionStart will be off by one
            if (box_int < 0)
            {
                powerOf10++;
            }
            //Calculate the amount to change the textbox value by.
            int valueChange = (int)Math.Pow(10.0, (double)powerOf10);
            if (e.KeyCode == Keys.Down)
            {
                box_int -= valueChange;
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                box_int += valueChange;
                e.Handled = true;
            }
            textBox.Text = box_int.ToString();
            textBox.SelectionStart = selStart;
        }
    }
