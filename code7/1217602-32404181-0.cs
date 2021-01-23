    dgv.CellPainting += dgv_CellPainting;
    void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
      if (e.ColumnIndex > -1 && e.RowIndex == -1) {
        if (e.ColumnIndex == 1) {
          int totalWidth = e.CellBounds.Width;
          for (int i = 2; i < 5; ++i) {
            totalWidth += dgv.Columns[i].Width;
          }
          Rectangle r = new Rectangle(e.CellBounds.Left, e.CellBounds.Top + 1, 
                                      totalWidth, e.CellBounds.Height - 16);
          e.Graphics.FillRectangle(Brushes.LightGray, r);
          TextRenderer.DrawText(e.Graphics, "IMPORT SITES", SystemFonts.DefaultFont,
                                new Rectangle(r.Left, r.Top, r.Width, r.Height - 4),
                                Color.Black, Color.Empty,
                                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
          e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(r.Left - 1, r.Top - 1, r.Width, r.Height));
        }
        if (e.ColumnIndex >= 1 && e.ColumnIndex <= 4) {
          Rectangle r = new Rectangle(e.CellBounds.Left, e.CellBounds.Top + e.CellBounds.Height - 16,
                                      e.CellBounds.Width, 16);
          e.Graphics.FillRectangle(Brushes.LightGray, r);
          
          TextRenderer.DrawText(e.Graphics, dgv.Columns[e.ColumnIndex].HeaderText,
            SystemFonts.DefaultFont, new Rectangle(r.Location, new Size(r.Width, r.Height - 2)),
            Color.Black, Color.Empty, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
          e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(r.Left - 1, r.Top - 1, r.Width, r.Height));
        } else {
          e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);
          TextRenderer.DrawText(e.Graphics, dgv.Columns[e.ColumnIndex].HeaderText,
            SystemFonts.DefaultFont, e.CellBounds, Color.Black, Color.Empty,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
          e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(e.CellBounds.Left - 1, e.CellBounds.Top,
                                                            e.CellBounds.Width, e.CellBounds.Height - 1));
        }
        e.Handled = true;
      }
    }
