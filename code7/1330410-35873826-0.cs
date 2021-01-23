    void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
      if (e.RowIndex == 1) {
        Rectangle r = e.RowBounds;
        e.Graphics.DrawLine(Pens.DarkRed, r.Left,
                                          r.Top + (r.Height / 2),
                                          r.Left + r.Width,
                                          r.Top + (r.Height / 2));
      }
    }
