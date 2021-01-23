    public static DataGrid BuildGrid(bool IncludeContacts , CheckBox chkRevToDate )
    {
     if (chkRevToDate.Checked) 
        {
                NewDg.Columns.Add(Load.CreateBoundColumn("RevToDate", "Re To Date (Net)"));
        }
    }
