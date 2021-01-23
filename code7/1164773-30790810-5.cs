    private void SaveChanges(object sender, RoutedEventArgs e)
    {
        DataGridRow dataGridRow;
        DataGridCellsPresenter dataGridCellsPresenter;
        DataGridCell dataGridCell;
        TextBox textBox;
        BindingExpression bindingExpression;
    
        for (int i = 0; i < Grid1.Items.Count; i++)
        {
            dataGridRow = (DataGridRow)Grid1.ItemContainerGenerator.ContainerFromIndex(i);
            dataGridCellsPresenter = GetVisualChild<DataGridCellsPresenter>(dataGridRow);
            for (int j = 0; j < Grid1.Columns.Count; j++)
            {
                dataGridCell = (DataGridCell)dataGridCellsPresenter.ItemContainerGenerator.ContainerFromIndex(j);
                textBox = FindVisualChild<TextBox>(dataGridCell, "textBox");
                if (textBox != null)
                {
                    bindingExpression = BindingOperations.GetBindingExpression(textBox, TextBox.TextProperty);
                    bindingExpression.UpdateSource();
                }
            }
        }
    }
