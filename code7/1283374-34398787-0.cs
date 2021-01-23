        private void button1_Click(object sender, EventArgs e)
        {
            string[] cmdTextParts = textBox1.Text.Split(',');
            foreach (string item in cmdTextParts)
            {
                cmdStreamWriter.WriteLine(item);
            }
        }
