    private Dictionary<string, bool> GetStatusForRow(UltraDataBand b,
                                                     UltraGridRow row)
            {
                
                Dictionary<string, bool> statusChecked = new Dictionary<string, bool>();
                foreach (UltraDataColumn col in b.Columns.Cast<UltraDataColumn>()
                                                 .Where(x => x.Tag != null &&
                                                        x.Tag.ToString() == "SITE_COL"))
                {
                    
                    statusChecked.Add(col.Key, Convert.ToBoolean(row.Cells[col.Key].Value));
    
                }
                return statusChecked;
            }
