    private void dataGrid1_CellDoubleClick(object sender, RoutedEventArgs e)
    {
        var cell = sender as DataGridCell;
        if (cell != null && cell.Content is TextBlock)
        {
            var textBlock = cell.Content as TextBlock;
            textBlock.SetCurrentValue(TextBlock.TextProperty, "put your text here");
            var binding = BindingOperations.GetBindingExpression(textBlock, TextBlock.TextProperty);
            binding.UpdateSource();
        }
    }
