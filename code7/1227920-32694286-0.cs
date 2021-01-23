    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            if (textBox1.Text != "")
            {
                Microsoft.Office.Interop.Word._Application oWord;
                object oMissing = Type.Missing;
                oWord = new Microsoft.Office.Interop.Word.Application();
                oWord.Visible = false;
                oWord.Documents.Open(filePath);
                oWord.ActiveDocument.Characters.Last.Select();  // Line 1
                oWord.Selection.Collapse();                     // Line 2
                oWord.Selection.TypeText(textBox1.Text);
                oWord.ActiveDocument.Save();
                oWord.Quit();
                MessageBox.Show("The text is inserted.");
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Please give some text in the text box");
            }
        }
        catch(Exception)
        {
            MessageBox.Show("Please right click on the window and provide the path");
        }
    }
