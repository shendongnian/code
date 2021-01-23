    /// <summary>
    /// Return selected file from winform save dialog
    /// </summary>
    /// <param name="fn">The filename</param>
    /// <param name="id">The initial directory</param>
    /// <returns>Specified filename</returns>
    private string SaveFileTo(string id, string fn)
    {
        SaveFileDialog fd = new SaveFileDialog();
        //fd.OverwritePrompt = false;
        fd.AddExtension = true;
        fd.ValidateNames = true;
        fd.FileName = fn;
        fd.InitialDirectory = id;
        //fd.Filter = "PDF files|*.pdf|Other ext like music|*.mp3;*.wma|All File|*.*";
        fd.Filter = "PDF files|*.pdf";
        if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            return fd.FileName;
        return "";
    }
