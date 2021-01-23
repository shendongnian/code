    //handle the SelectionChanged event
    private void dgvConfig_SelectionChanged(object sender, 
                                            SelectionChangedEventArgs e){
       //set the CurrentCell to the cell on the current row 
       //in the second column
       if(dgvConfig.Columns.Count > 1){
          dgvConfig.CurrentCell = new DataGridCellInfo(dgvConfig.SelectedItem,
                                                       dgvConfig.Columns[1]);
       }
    }
