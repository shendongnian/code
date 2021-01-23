    private void timer1_Tick(object sender, EventArgs e) {
      Control c = FindControlAtPoint(this, this.PointToClient(Control.MousePosition));
      if (c != null) {
        Point p = c.PointToClient(Control.MousePosition);
        p.Offset(10, 10);
        m_tooltip.Show("Found " + c.Name, c, p);
        m_tooltip.Active = true;
      } else {
        m_tooltip.Active = false;
      }
    }
