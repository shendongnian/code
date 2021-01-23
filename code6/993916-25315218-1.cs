    private void newRecordBtn_Click(object sender, RoutedEventArgs e)
    {
        if (e.Source == newRecordBtn)
        {
            ExecuteNewRecordButtonCommand();
            e.Handled = true;
        }
    }
    private void ExecuteNewRecordButtonCommand()
    {
        if (newRecordBtn.Command.CanExecute(null))
        {
            newRecordBtn.Command.Execute(null);
            if (detailsDataGrid.Items.Count > 0)
            {
                detailsDataGrid.UpdateLayout();
                DataGridRow selectedRow = 
                    (DataGridRow)(detailsDataGrid.ItemContainerGenerator
                                                    .ContainerFromItem(detailsDataGrid.SelectedItem));
                DataGridCellsPresenter cellPresenter = FindVisualChild<DataGridCellsPresenter>(selectedRow);
                    
                System.Windows.Controls.DataGridCell firstCell =
                    (System.Windows.Controls.DataGridCell)(cellPresenter.ItemContainerGenerator
                                                                        .ContainerFromIndex(0));
                firstCell.Focus();
                firstCell.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
    }
