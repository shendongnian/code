    protected void Button3_Click(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0)
      {
        DataGridViewRow row = this.Rows[e.RowIndex];
        string barcode = row.Cells["ID"].Value.ToString();        
      }
    }
