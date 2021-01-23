    private void button5_Click(object sender, EventArgs e)
    {
        RichTextBox newbox = new RichTextBox();
        String Saved_Module = Path.Combine("C:\\Modules", txtModuleName.Text + ".txt");
        newbox.AppendText(txtModuleName.Text + "\n" + ModuleDueDate.Text + "\n" + txtModuleInfo.Text + "\n" + txtModuleLO.Text);
        newbox.SaveFile(Saved_Module, RichTextBoxStreamType.PlainText);
    
        Directory.CreateDirectory(Path.Combine(@"C:\Modules", txtModuleName.Text));
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
