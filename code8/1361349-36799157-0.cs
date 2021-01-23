    private void button1_Click(object sender, EventArgs e)
    {
    	var wordCount = CountWords(textBox1.Text);
    	MessageBox.Show(wordCount.ToString());
    
    }
    private int CountWords(string input)
    {
    	var separators = new[] { ' ', '.' };
    	var count = input.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length;
    	return count;
    }
