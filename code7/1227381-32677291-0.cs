    01  private void maingrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    02  {
    03      TextBox t = e.EditingElement as TextBox;
    04      DataGridColumn dgc = e.Column;
    05      if ((string)dgc.Header == "Product Id")
    06      {
    07          if (vm_order.PopulateProductRow(maingrid.SelectedIndex, Convert.ToInt32(t.Text)) == false)
    08          {
    09              MessageBox.Show("Product does not exists           ", "Message", MessageBoxButton.OK);
    10          }
    11      }
    12
    13      mainGrid.PreviewKeyDown += new KeyEventHandler(mainGrid_PreviewKeyDown);
    14  }
