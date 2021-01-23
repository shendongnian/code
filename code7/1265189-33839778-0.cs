    i think you can write function to check text entered in richtext box and call when required.
    
        private void richTextBox1_TextChanged(object sender, EventArgs e)
            {
               if(your condition)
                {
                CheckRichTextEntered(richTextBox1.Text)
                }
            }
        
        
            public void CheckRichTextEntered(string RichBoxText)
            {
                    int token = -1;
                    int token2 = -1;
            
                    foreach (string line in richTextBox1.Lines)
                    {
                        if (line.Contains("<") || line.Contains(">"))
                        {
                            while (richTextBox1.Text.IndexOf("<") > -1 && richTextBox1.Text.IndexOf(">") > -1)
                            {
                                token = richTextBox1.Text.IndexOf("<");
                                token2 = richTextBox1.Text.IndexOf(">", token) + 1;
                                string clip = richTextBox1.Text.Substring(token, token2 - token);
                                richTextBox1.Select(token, token2 - token);
                                if (richTextBox1.SelectedText.Length > 0)
                                {
                                    richTextBox1.Text = richTextBox1.Text.Replace(richTextBox1.Text.Substring(richTextBox1.SelectionStart, richTextBox1.SelectionLength), " ");
                                }
                                richTextBox1.AppendText(" ");
                            }
                        }
                    }
            }
