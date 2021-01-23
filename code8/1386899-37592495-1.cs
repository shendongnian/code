    private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim().Length == 4)
            {
                TextBox2.BecomeFirstResponder();
            }
        }
