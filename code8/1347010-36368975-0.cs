    private void button1_Click(object sender, EventArgs e)
            {
                String Saved_Module = Path.Combine("C:\\Module", txtModuleName.Text);
                allrtb.SaveFile(Saved_Module, RichTextBoxStreamType.PlainText);
    
            }
