    private string friendlyErrorMessage = "An error has occurred inside the Case Manager Word Addin";
    //static string filePath = null;           
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        this.Application.DocumentBeforeClose += Application_DocumentBeforeClose;
    }
    //public static string dialogFilePath;
    public static string dialogFileName;
    public static Word.Document doc;
    void Application_DocumentBeforeClose(Word.Document document, ref bool Cancel)
    {
        try
        {
            string filePath = this.Application.ActiveDocument.FullName.ToString();
            string fileName = this.Application.ActiveDocument.Name;
            //dialogFilePath = filePath;
            dialogFileName = fileName;
            doc = document;
            string tempFile;
            string tempPath;
            //var form = new SaveFileDialog();
            //form.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //form.ShowDialog();
            //System.Windows.Forms.MessageBox.Show(form.ToString());
            //_T is for editing template and save file after saving.
            //+ is for saving 
           
                    //document.Save();
                    var iPersistFile = (IPersistFile)document;
                    iPersistFile.Save(tempPath, false);
                    if (filePath.Contains("_T"))
                    {
                        //Store file into DB
                    }
                    else
                    {
                        //Store file into DB
                    }
                //object doNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
                //document.Close(ref doNotSaveChanges, ref missing, ref missing);
                Word._Document wDocument = Application.Documents[fileName] as Word._Document;
                //wDocument.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                ThisAddIn.doc.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
        }
        catch (Exception exception)
        {
        }
    }
    private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
    {
    }
    #region VSTO generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InternalStartup()
    {
        this.Startup += new System.EventHandler(ThisAddIn_Startup);
        this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
    }
    #endregion
