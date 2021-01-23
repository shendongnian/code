    DateTime rowtype = Convert.ToDateTime(row.Cells["CreatedOn"].Value);
    string status= row.Cells["Status"].Value.ToString();
    DateTime dt = new DateTime(rowtype.Year, rowtype.Month, rowtype.Day);
    DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    if (dt == today.AddDays(-7)  &&  status == "Open")
    {
        row.HeaderCell.Value = ">7";
    }
