    this.YourDataTable.ColumnChanging += YourDataTableColumnChangingStuff;
    private void YourDataTableColumnChangingStuff(object sender, DataColumnChangeEventArgs e)
    {
       private void EmployeeDataTable_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            //just validate "e.ProposedValue.ToString()" with necessary
            if ("" != e.ProposedValue.ToString())
                e.ProposedValue = DateTime.Now.ToString();
        }
    }
