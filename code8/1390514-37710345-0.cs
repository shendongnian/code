    SaveFileDialog dialog = new SaveFileDialog();
    dialog.Filter = "Text File|*.txt";
    var result = dialog.ShowDialog();
    if (result != DialogResult.OK)
        return;
    
    // setup for export
    dgvSum.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
    dgvSum.SelectAll();
    // hiding row headers to avoid extra \t in exported text
    var rowHeaders = dgvSum.RowHeadersVisible;
    dgvSum.RowHeadersVisible = false;
    
    // ! creating text from grid values
    string content = dgvSum.GetClipboardContent().GetText();
                
    // restoring grid state
    dgvSum.ClearSelection();
    dgvSum.RowHeadersVisible = rowHeaders;
    
    System.IO.File.WriteAllText(dialog.FileName, content);
    MessageBox.Show(@"Text file was created.");
