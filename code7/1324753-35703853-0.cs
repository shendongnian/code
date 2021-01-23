    void DG_dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
      if (e.Button == MouseButtons.Right) {
        if (e.ColumnIndex > -1) {
          Rectangle r = DG_dataGridView.GetColumnDisplayRectangle(e.ColumnIndex, true);
          RightClickToolStrip.Show(DG_dataGridView, r.Left + e.X, r.Top + e.Y);
        }
      }
    }
