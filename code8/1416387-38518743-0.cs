    public void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
            if ((int)(e.KeyChar) != 8)
            {
                if ((((int)(e.KeyChar) < 48 | (int)(e.KeyChar) > 57) & (int)(e.KeyChar) != 46) | ((int)(e.KeyChar) == 46 & textBox1.Text.Contains(".")))
                {
                    e.Handled = true;
                }
                else
                {
                    if (!textBox1.Text.Contains("."))
                    {
                        int iLength = textBox1.Text.Replace(",", "").Length;
                        if (iLength % 3 == 0 & iLength > 0)
                        {
                            if ((int)(e.KeyChar) != 46)
                            {
                                textBox1.AppendText(",");
                            }
                        }
                    }
                }
            }
            else
            {
                if (textBox1.Text.LastIndexOf(",") == textBox1.Text.Length - 2 & textBox1.Text.LastIndexOf(",") != -1)
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.LastIndexOf(","), 1);
                    textBox1.SelectionStart = textBox1.Text.Length;
                }
            }
        }
