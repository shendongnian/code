    private void btnEdit_Click(object sender, EventArgs e)
    {
        RichTextBox rchTemp = new RichTextBox();
        foreach (string line in rchCode.Lines)
        {
            rchTemp.AppendText("\r\n" + line.Trim());
        }
        
        RichTextBox rchTemp2 = new RichTextBox();
        int indentCount = 0;
        bool shouldIndent = false;
        foreach (string line in rchTemp.Lines)
        {
            if (shouldIndent)
            indentCount++;
            
        if (line.Contains("}"))
        indentCount--;
        
        if (indentCount == 0)
        {
            rchTemp2.AppendText("\r\n" + line);
            shouldIndent = line.Contains("{");
                continue;
            }
            string blankSpace = string.Empty;
            for (int i = 0; i < indentCount; i++)
            {
                blankSpace += "    ";
            }
            rchTemp2.AppendText("\r\n" + blankSpace + line);
            shouldIndent = line.Contains("{");
            }
            rchCode.Text = rchTemp2.Text;
        }
    }
