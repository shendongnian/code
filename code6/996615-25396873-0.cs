    private void CustomizedTableView_CopyingToClipboard(object sender, CopyingToClipboardEventArgs e)
    {
        TableView view = sender as TableView;
        if (view == null || view.Grid == null)
            return;
        string text = null;
        if (view.ActiveEditor != null)
            text = view.ActiveEditor.DisplayText;
        else
        {
            object value = view.Grid.CurrentCellValue;
            if (value != null)
                text = value.ToString();
        }
        if (text == null)
            return;
        VantageUtilities.SafeCopyToClipboard(DataFormats.Text, text);
        e.Handled = true;
    }
