    void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
      if (e.Value != null && e.Value.ToString() != "" && (int)e.Value == 0) {
        e.Value = string.Empty;
        e.FormattingApplied = true;
      }
    }
