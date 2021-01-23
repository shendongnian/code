    private void DataGridView1_ColumnAdded(Object sender, DataGridViewColumnEventArgs e) {
    
    if(e.Column.ValueType is DateTime) {
              e.Column = new MyCalendarColumn();
           }
    }
