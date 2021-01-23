    var dataGridRow = Tools.FindChild(testCasesDataGrid, x =>
    {
        var element = x as DataGridRow;
        if (element != null && element.Item == System.Windows.Data.CollectionView.NewItemPlaceholder)
            return true;
        else
            return false;
    }) as DataGridRow;
    var textBlock = Tools.FindChild(dataGridRow, x =>
    {
        return x is TextBlock;
    }) as TextBlock;
    textBlock.Text = "new row...";
    textBlock.Foreground = System.Windows.Media.Brushes.Gray;
