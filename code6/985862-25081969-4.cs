    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        bool handled = false;
        //test if digit
        if (char.IsDigit(e.KeyChar))
        {
            //only allow 2 digits
            //test if length is long enough to contain a prior char
            if (textBox1.Text.Length - 1 >= 0)
            {
                //test if prior char is digit
                if (char.IsDigit(textBox1.Text[textBox1.Text.Length -1]))
                {
                    //test if length is long enough to have 2nd prior char
                    if (textBox1.Text.Length -2 >= 0)
                    {
                        //test 2 prior char if it's a digit because you
                        //only want to allow 2 not 3
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
            if (textBox1.Text.Count(t => t.Equals('.')).Equals(3))
            {
                handled = true;
            }
            else
            {
                //don't allow multiple decimals next to each other
                //test if we have prior char
                if (textBox1.Text.Length - 1 >= 0)
                {
                    //test if prior char is decimal
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
