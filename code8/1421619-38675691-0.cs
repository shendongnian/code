<Code>
 private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                button1.Enabled = true;
            }
</Code>
