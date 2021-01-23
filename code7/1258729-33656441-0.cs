    public class ListBoxEx : ListBox {
      private const int WM_MOUSEMOVE = 0x200;
      private const int WM_LBUTTONDOWN = 0x201;
      private const int WM_KEYDOWN = 0x100;
      private const int VK_LEFT = 0x25;
      private const int VK_UP = 0x26;
      private const int VK_RIGHT = 0x27;
      private const int VK_DOWN = 0x28;
      protected override void WndProc(ref Message m) {
        // Get params as int
        int lParam = m.LParam.ToInt32();
        int wParam = m.WParam.ToInt32();
        // Intercept mouse selection
        if (m.Msg == WM_MOUSEMOVE || m.Msg == WM_LBUTTONDOWN) {
          Point clickedPt = new Point();
          clickedPt.X = lParam & 0x0000FFFF;
          clickedPt.Y = lParam >> 16;
          // If point is on a disabled item, ignore mouse
          for (int i = 0; i < Items.Count; i++)
            if (string.IsNullOrWhiteSpace(Items[i].ToString()) &&
              GetItemRectangle(i).Contains(clickedPt))
              return;
        }
        // Intercept keyboard selection
        if (m.Msg == WM_KEYDOWN)
          if (wParam == VK_DOWN || wParam == VK_RIGHT) {
            // Select next enabled item
            for (int i = SelectedIndex + 1; i < Items.Count; i++)
              if (!string.IsNullOrWhiteSpace(Items[i].ToString())) {
                SelectedIndex = i;
                break;
              }
            return;
          } else if (wParam == VK_UP || wParam == VK_LEFT) {
            // Select previous enabled item
            for (int i = SelectedIndex - 1; i >= 0; i--)
              if (!string.IsNullOrWhiteSpace(Items[i].ToString())) {
                {
                  SelectedIndex = i;
                  break;
                }
              }
            return;
          }
        base.WndProc(ref m);
      }
      protected override void OnDrawItem(DrawItemEventArgs e) {
        if (e.Index > -1) {
          string item = this.Items[e.Index].ToString();
          if (string.IsNullOrWhiteSpace(item)) {
            e.Graphics.DrawLine(Pens.DarkGray, new Point(e.Bounds.X + 5, e.Bounds.Y + 7),
                                               new Point(e.Bounds.Right - 5, e.Bounds.Y + 7));
          } else {
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
              e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
              TextRenderer.DrawText(e.Graphics, item, e.Font, e.Bounds, SystemColors.HighlightText);
            } else {
              e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
              TextRenderer.DrawText(e.Graphics, item, e.Font, e.Bounds, SystemColors.WindowText);
            }
          }
        }
        base.OnDrawItem(e);
      }
    }
