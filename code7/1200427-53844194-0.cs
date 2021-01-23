    IXLCell JobCell = row.Cells().Where(item => item.Address.ColumnLetter == "B").FirstOrDefault(); }
    string Job = JobCell.RichText.Text;
    if (string.IsNullOrEmpty(Job))
    {
       Job = JobCell.ValueCached;
    }
