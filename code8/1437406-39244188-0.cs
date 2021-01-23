    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        Globals.ThisAddIn.Application.DocumentBeforeSave += Application_DocumentBeforeSave;
     
    }    
    
    void Application_DocumentBeforeSave(Word.Document Doc, ref bool SaveAsUI, ref bool Cancel)
    {
        SaveFileDialog dgSave = new SaveFileDialog();
        dgSave.Title = "This is my save dialog";
        dgSave.FileName = "This is the initial name";
        dgSave.InitialDirectory = "C:\\Temp";
        dgSave.FileOk += dgSave_FileOk;
        DialogResult result = dgSave.ShowDialog();
    }
        
    void dgSave_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
        var test = (SaveFileDialog)sender;
        MessageBox.Show("You clicked on SAVE and this file is selected " + test.FileName);
    }
