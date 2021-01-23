    this.YourDataTable.ColumnChanging += YourDataTableColumnChangingStuff;
    private void YourDataTableColumnChangingStuff(object sender, DataColumnChangeEventArgs e)
    {
        if(e.Column.ColumnName == "YourColumnTestName")
        {
           var errormsg = MyValidateTestNameMethod(e.ProposedValue);
           e.Row.SetColumnError(e.Column.ColumnName, errormsg);
        }
        //...
    }
