    private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            var pressedCell = e.OriginalSource as DataGridCell;
            if (pressedCell != null)
            {
                var textBlock = FindVisualChild<TextBlock>(pressedCell);
                if (textBlock != null)
                {
                    MessageBox.Show("Text: " + textBlock.Text); 
                    //or more useful stuff
                }
            }
        }
    }
