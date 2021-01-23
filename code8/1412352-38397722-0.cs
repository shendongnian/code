    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // If the column is the ShiftDuration column, check the
        // value.
        if (this.dataGridView1.Columns[e.ColumnIndex].Name == "ShiftDuration")
        {
            ShortFormDateFormat(e);
        }
    }
    
    private static void ShortFormDateFormat(DataGridViewCellFormattingEventArgs formatting)
    {
        if (formatting.Value != null)
        {
            try
            {
                DateTime theDate = DateTime.Parse(formatting.Value.ToString());
                String dateString = theDate.toString("hh:mm:ss tt");    
                formatting.Value = dateString;
                formatting.FormattingApplied = true;
            }
            catch (FormatException)
            {
                // Set to false in case there are other handlers interested trying to
                // format this DataGridViewCellFormattingEventArgs instance.
                formatting.FormattingApplied = false;
            }
        }
    }
