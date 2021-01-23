    this.YourDataTable.ColumnChanging += YourDataTableColumnChangingStuff;
    private void YourDataTableColumnChangingStuff(object sender, DataColumnChangeEventArgs e)
    {
       private void EmployeeDataTable_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
             //if you want to leave previous value 
            if ("incorrect value" != e.ProposedValue.ToString())
                e.ProposedValue = e.Row.ItemArray[e.Column.Ordinal];
            else
            {
                //if you want to set new value
                e.ProposedValue = "new value";
            }            
        }
    }
