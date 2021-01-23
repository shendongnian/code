    public class RichTextWithBanner : RichTextBox {
      private const int WM_PAINT = 0xF;
      protected override void OnTextChanged(EventArgs e) {
        base.OnTextChanged(e);
        this.Invalidate();
      }
      protected override void WndProc(ref Message m) {
        base.WndProc(ref m);
        if (m.Msg == WM_PAINT && this.Text == string.Empty) {
          using (Graphics g = Graphics.FromHwnd(m.HWnd)) {
            TextRenderer.DrawText(g, "Type Something", this.Font,
                this.ClientRectangle, Color.DarkGray, Color.Empty,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
          }
        }
      }
    }
