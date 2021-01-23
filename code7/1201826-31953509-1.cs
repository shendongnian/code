        // Paint the cell when not in edit mode.
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
          if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
          {
            if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell)
            {
              var cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
              var foreColor = cell.Style.ForeColor.Name == "0" ? Color.Black : cell.Style.ForeColor;
    
              e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);
              e.Paint(e.ClipBounds, DataGridViewPaintParts.ContentBackground);
    
              using (Brush forebrush = new SolidBrush(foreColor))
              using (Brush backbrush = new SolidBrush(cell.Style.BackColor))
              using (StringFormat format = new StringFormat())
              {
                Rectangle rect = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 19, e.CellBounds.Height - 3);
                format.LineAlignment = StringAlignment.Center;
    
                e.Graphics.FillRectangle(backbrush, rect);
                e.Graphics.DrawString(cell.FormattedValue.ToString(), e.CellStyle.Font, forebrush, rect, format); 
              }
              
              e.Paint(e.ClipBounds, DataGridViewPaintParts.ErrorIcon);
              e.Paint(e.ClipBounds, DataGridViewPaintParts.Focus);
              e.Handled = true;
            }
          }
        }
        // Paint the cell in edit mode.
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
          if (this.dataGridView1.CurrentCellAddress.X == combo.DisplayIndex)
          {
            ComboBox cb = e.Control as ComboBox;
            if (cb != null)
            {
              cb.DropDownStyle = ComboBoxStyle.DropDownList;
    
              cb.DrawMode = DrawMode.OwnerDrawFixed;
              cb.DrawItem -= this.cb_DrawItem;
              cb.DrawItem += this.cb_DrawItem;
            }
          }
        }
    
        // Manually paint the combobox.
        private void cb_DrawItem(object sender, DrawItemEventArgs e)
        {
          ComboBox cb = sender as ComboBox;
          // Non-sourced vs sourced examples.
          string value = cb.Items[e.Index].ToString();
          // string value = (cb.DataSource as DataTable).Rows(e.Index).Item("Source Column");
    
          if (e.Index >= 0)
          {
            using (Brush forebrush = new SolidBrush(cb.ForeColor))
            using (Brush backbrush = new SolidBrush(cb.BackColor))
            {
              e.Graphics.FillRectangle(backbrush, e.Bounds);
              e.DrawBackground();
              e.DrawFocusRectangle();
              e.Graphics.DrawString(value, e.Font, forebrush, e.Bounds);
            }
          }
        }
