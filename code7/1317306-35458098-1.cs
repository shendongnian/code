      var newData = // your data as DataTable Format;
      // Get Current Scroll position
      var scrollingRowIndex = MyDataGridView.FirstDisplayedScrollingRowIndex;
      // Get Current Row
      var currentRow = MyDataGridView.CurrentCell != null
                                     ? MyDataGridView.CurrentCell.RowIndex
                                     : -1;
      DataTable bindedData;
      var currentDataSource = MyDataGridView.DataSource as DataTable;
      
      if (currentDataSource != null)
      {
           currentDataSource.Merge(newData);
           bindedData = currentDataSource;
      }
      else
      {
          bindedData = newData;
      }
      MyDataGridView.DataSource = bindedData;
      MyDataGridView.Update();
      // set Current Scroll position
      if (scrollingRowIndex > -1)
             MyDataGridView.FirstDisplayedScrollingRowIndex = scrollingRowIndex;
      // set Current Row
      if (currentRow > -1)
             MyDataGridView.Rows[currentRow].Selected = true;
