    public static class FontHelper
    {
        public static void Underline(this RichTextBox txtBox, int underlineStart, int length)
        {
            if (underlineStart > 0)
            {
                txtBox.SelectionStart = underlineStart;
                txtBox.SelectionLength = length;
                txtBox.SelectionFont = new Font(txtBox.SelectionFont, FontStyle.Underline);
                txtBox.SelectionLength = 0;
            }
        }        
    }
    richTextBox1.Text = "Search for";
    richTextBox1.Underline(7, 1);   // index and length of underlying text
