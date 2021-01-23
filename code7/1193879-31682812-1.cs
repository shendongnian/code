    private void btn_Search_Click(object sender, EventArgs e)
    {
        var wordsToHighlight = new List<string>()
        {
            "Exit", "Close", "Leave"
        };
        if (!string.IsNullOrWhiteSpace(richTextBox1.Text))
        {
            foreach (var word in wordsToHighlight)
	        {
                int index = 0;
                while (index != -1)
                {
                    richTextBox1.SelectionColor = Color.Cyan;
                    index = richTextBox1.Find(word, index + word.Length - 1, richTextBox1.TextLength, RichTextBoxFinds.None);
                }
	        }
        }
    }
