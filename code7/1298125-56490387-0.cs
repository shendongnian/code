    public string searchExpress = string.Empty;
    public int findPos = 0;
    private void reverseSearchButton_Click(object sender, EventArgs e)
        {
            // this is to check whether new search term is written in searchbox toolStripTextBox2
            string findterm = string.Empty;
            findterm = toolStripTextBox2.Text;
            if (findterm != searchExpress)
            {
                findPos = GetRichTextBox().TextLength;
                searchExpress = findterm;
            }
            
            if (toolStripTextBox2.Text.Length > 0)
            {
                try
                {
                    
                    
                    
                    findPos = GetRichTextBox().Find(findterm, 0, GetRichTextBox().SelectionStart , RichTextBoxFinds.Reverse);
                    
                    GetRichTextBox().Select(findPos, toolStripTextBox2.Text.Length);
                    GetRichTextBox().ScrollToCaret();
                    GetRichTextBox().Focus();
                    findPos += toolStripTextBox2.Text.Length + 1;
                    
                }
                catch
                {
                    findPos = 0;
                }
            }
        }
