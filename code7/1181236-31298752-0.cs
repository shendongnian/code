        void AboutBox_Load(object sender, EventArgs e)
        {
            this.ColorPrefix(richTextBox1, "[b]", Color.Green);
            this.ColorPrefix(richTextBox1, "[f]", Color.Red); // change the color!
            this.ColorPrefix(richTextBox1, "[e]", Color.Yellow); // change the color!
        }
        private void ColorPrefix(RichTextBox rtb, string prefix, Color color)
        {
            int position = 0, index = 0;
            while ((index = rtb.Find(prefix, position, RichTextBoxFinds.None)) >= 0)
            {
                rtb.Select(index, prefix.Length);
                rtb.SelectionColor = color;
                position = index + 1;
            }
            rtb.Select(rtb.TextLength, 0);
        }
