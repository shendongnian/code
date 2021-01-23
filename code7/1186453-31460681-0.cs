    private void edit()
    {
      DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
      Editlink.Name = "Edit"; // ADD
      // ...
    }
    private void GetReceipt(bool mode)
    {
      // ...
      try
      {
        if (mode == false)
          // ...
        else
        {
          this.dataGridView1.DataSource = null;
          this.dataGridView1.Columns.Clear(); // ADD
          // ...
        }
      }
      // ...
    }
    private void receiptGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // ...
            if (receiptGrid.Columns[e.ColumnIndex].Name == "Edit") // CHANGE
        // ...
    }
    
