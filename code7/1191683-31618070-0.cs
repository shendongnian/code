        private void button1_Click(object sender, EventArgs e)
        {
            ColorLine(0, Color.Green);
            ColorLine(2, Color.Blue);
        }
        private void ColorLine(int line, Color clr)
        {
            int index = richTextBox1.GetFirstCharIndexFromLine(line);
            int length = richTextBox1.Lines[line].Length;
            richTextBox1.Select(index, length);
            richTextBox1.SelectionColor = clr;
            richTextBox1.Select(0, 0);
        }
