            private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int idx = richTextBox1.Text.IndexOf(textBox1.Text);
            if (idx > -1)
            {
                richTextBox1.SelectionStart = idx;
                richTextBox1.SelectionLength = textBox1.Text.Length;
                richTextBox1.SelectionColor = Color.White;
                richTextBox1.SelectionBackColor = Color.LightGreen;
            }
        }
