    private void CopyAsCsvHandler(DataGrid dg)
    {
        dg.SelectAllCells();
        dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
        ApplicationCommands.Copy.Execute(null, dg);
        dg.UnselectAllCells();
        LivePreviewText = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
    }
