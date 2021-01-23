    this.dataGridView1.Columns[0].DefaultCellStyle.Format = "000.0";
    this.dataGridView1.Columns[1].DefaultCellStyle.Format = "00-00-00";
    this.dataGridView1.CellFormatting += this.DataGridView1_CellFormatting;
    private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      int value = 0;
      if (e.Value != null && int.TryParse(e.Value.ToString(), out value))
      {
        if (e.ColumnIndex == 0)
        {
          // Must manually move decimal. Setting Format will not do this for you.
          e.Value = (decimal)value / 10;
        }
        else if (e.ColumnIndex == 1)
        {
          // Format won't affect e.Value of type string.
          e.Value = value;
        }
      }
    }
