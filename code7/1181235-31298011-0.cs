        private void AboutBox_Load(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            int position = 0, index = 0;
            while ((index = text.IndexOf("[b]", position)) >= 0)
            {
                richTextBox1.Select(index, 3);
                richTextBox1.SelectionColor = Color.Green;
                position = index + 1;
            }
        }
