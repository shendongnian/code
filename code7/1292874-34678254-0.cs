    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        var sel = textBox2.SelectionStart;
        if (string.IsNullOrWhiteSpace(textBox2.Text))
        {
            textBox2.Text = "000";
            return;
        }
        if (sel != 0)
        {
            var symbol_entered = textBox2.Text.Substring(sel - 1, 1);
            if (!Char.IsDigit(symbol_entered.ToCharArray()[0]))
            {
                sel--;
                textBox2.Text = textBox2.Text.Remove(sel, 1);
            }
            else
            { // entered a digit
                if (textBox2.Text.Length == 4 && textBox2.SelectionStart == 4) // last digit entered 
                    textBox2.Text = textBox2.Text.Substring(0, 3).PadLeft(3, '0'); // trim it
                else if (textBox2.Text.Length == 4)
                    textBox2.Text = textBox2.Text.Remove(sel, 1);
             }
        }
        if (!string.IsNullOrWhiteSpace(textBox2.Text)) // removed the first digit
        {
            textBox2.Text = textBox2.Text.PadLeft(3, '0'); // trim it
            textBox2.SelectionStart = sel;
        }
    }
