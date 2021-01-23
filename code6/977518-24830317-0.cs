    // make this a variable in the class instead of the method
    private int findPos = 0;
    void Button12_Click(object sender, EventArgs e)
    {
        string searchText = textBox2.Text ;
        try
        {
            string s = textBox2.Text;
            richTextBox1.Focus();
            findPos = richTextBox1.Find(s, findPos, RichTextBoxFinds.None);
            richTextBox1.Select(findPos, s.Length);
            findPos += textBox2.Text.Length +1;
            //i = richTextBox1.Find(s, i + s.Length, RichTextBoxFinds.None);
        }
        catch
        {
            MessageBox.Show("No Occurences Found");
            findPos = 0;
        }
    }
