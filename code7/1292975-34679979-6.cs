        private void button1_Click(object sender, EventArgs e)
        {
            var d = letterCounter(textBox1.Text);
            textBox2.Text = string.Empty;
            foreach(char c in d.Keys)
            {
                 textBox2.Text += d[c].count.ToString() + " ";
            }
        }
