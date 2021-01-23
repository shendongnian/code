    void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
      if (e.Value != null) {
        if (dgv.Columns[e.ColumnIndex].Name == "kesim" | 
            dgv.Columns[e.ColumnIndex].Name == "torna" ) {
          if (e.Value.ToString() == "True") {
            e.CellStyle.BackColor = Color.Green;
          } else {
            e.CellStyle.BackColor = Color.Red;
          }
        }
      }
    }
