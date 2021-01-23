    private void button1_Click(object sender, EventArgs e)
    {
        string cLine = "Taw:  Hello World";  // use your own lines!
        var  chatstr = cLine.Split(new string[] { ": " }, 2, StringSplitOptions.None);
        AppendLineBold(yourrichTextBox, "\n" + chatstr[0], true);
        AppendLineBold(yourrichTextBox, chatstr[1], false);
        yourrichTextBox.ScrollToCaret();
    }
    void AppendLineBold(RichTextBox rtb, string text, bool bold)
    {
        rtb.SelectionStart = richTextBox1.Text.Length;
        rtb.SelectionLength = 0;
        using (Font font = new Font(rtb.SelectionFont, 
                                    bold ? FontStyle.Bold : FontStyle.Regular))
            rtb.SelectionFont = font;
        rtb.AppendText(text);
    }
