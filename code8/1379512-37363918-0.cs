    List<int> getColorPositions(RichTextBox rtb, Color col)
    {
        List<int> pos = new List<int>();
        for (int i = 0; i < rtb.Text.Length; i++)
        {
            rtb.SelectionStart = i;
            richTextBox1.SelectionLength = 1;
            if (rtb.SelectionColor.ToArgb() == col.ToArgb() ) pos.Add(i);
        }
        return pos;
    }
