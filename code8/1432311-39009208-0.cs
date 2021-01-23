    private void AppendTextBoxLine(string myStr)
        {
    	if (textBox1.Text.Length > 0)
    	{
    	    textBox1.AppendText(Environment.NewLine);
    	}
    	textBox1.AppendText(myStr);
        }
    
        private void TestMethod()
        {
    	for (int i = 0; i < 2; i++)
    	{
    	    AppendTextBoxLine("Some text");
    	}
        }
