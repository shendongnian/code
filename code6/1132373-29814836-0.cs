    DataTable dt = new DataTable();
    dt.Columns.Add("FirstName");
    dt.Columns.Add("LastName");
    foreach(var oItem in YourList)
    {
         dt.Rows.Add(new object[] { oItem.FirstName, oItem.LastName });
    }
    myDataGridView.DataSource = dt;
