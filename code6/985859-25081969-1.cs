    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        bool handled = false;
        //test if digit
        if (char.IsDigit(e.KeyChar))
        {
            //only allow 2 digits
            if (textBox1.Text.Length - 1 >= 0)
            {
                if (char.IsDigit(textBox1.Text[textBox1.Text.Length -1]))
                {
                    if (textBox1.Text.Length -2 >= 0)
                    {
                        if (char.IsDigit(textBox1.Text[textBox1.Text.Length - 2]))
                        {
                            handled = true;
                        }
                    }
                }
            }
        }
        //test if decimal
        else if (e.KeyChar.Equals('.'))
        {
            //only allow 4 decimals
            if (textBox1.Text.Count(t => t.Equals('.')).Equals(4))
            {
                handled = true;
            }
            else
            {
                //don't allow multiple decimals next to each other
                if (textBox1.Text.Length - 1 >= 0)
                {
                    if (textBox1.Text[textBox1.Text.Length - 1].Equals('.'))
                    {
                        handled = true;
                    }
                }
            }
        }
        else
        {
            handled = true;
        }
        e.Handled = handled;
    }
