     private void dgv_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DateTime dateValue;
            
            // Confirm that the cell is not empty.
            if (!string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (DateTime.TryParseExact(e.Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                {
                    e.Value = dateValue;
                    e.ParsingApplied = true;                
                }
            }
        }
