    private Dictionary<string, bool> GetStatusForRow(UltraGridBand b, 
                                                     UltraGridRow row)
    {
        Dictionary<string, bool> statusChecked = new Dictionary<string, bool>();
        foreach (UltraGridColumn col in b.Columns.Cast<UltraGridColumn>()
                                         .Where(x => x.Tag != null && 
                                                x.Tag.ToString() == "SITE_COL"))
        {
            statusChecked.Add(col.Key, Convert.ToBoolean(row.Cells[col].Value));
        }
        return statusChecked;
    }
