    private void tabControl_MouseMove(object sender, MouseEventArgs e) {
      TabControl tc = sender as TabControl;
      for (int i = 0; i < tc.TabPages.Count; i++) {
        Rectangle r = tc.GetTabRect(i);
        Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 12, 12);
        if (closeButton.Contains(e.Location)) {
          if (mousedOver != i) {
            mousedOver = i;
            tc.Invalidate(r);
          }
        } else if (mousedOver == i) {
          int oldMouse = mousedOver;
          mousedOver = -1;
          tc.Invalidate(tc.GetTabRect(oldMouse));
        }
      }
    }
