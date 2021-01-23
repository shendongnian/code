    dg.SelectAllCells();
    dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
    ApplicationCommands.Copy.Execute(null, dg);
    
    string dataGridContent = (string)Clipboard.GetData(DataFormats.Html);
    dataGridContent = dataGridContent.Replace("<TABLE>",
        String.Format("<TABLE><TR><TD colspan='{0}'>Your additional text<TD></TR>", dg.Columns.Count));
    
    Clipboard.SetText(dataGridContent, TextDataFormat.Html);
