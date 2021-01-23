    private int mHScroll;
    protected override void WndProc(ref System.Windows.Forms.Message msg) {
      if (msg.Msg == WM_HSCROLL) {
        switch ((int)msg.WParam & 0xffff) {
        case SB_PAGELEFT:
          mHScroll = Math.Max(0, mHScroll - ClientSize.Width * 2 / 3); //A page is 2/3 the width.
          break;
        case SB_PAGERIGHT:
          mHScroll = Math.Min(HorizontalExtent, mHScroll + ClientSize.Width * 2 / 3);
          break;
        case SB_THUMBPOSITION:
        case SB_THUMBTRACK:
          mHScroll = ((int)msg.WParam >> 16) & 0xffff;
          break;
        }
      }
      base.WndProc(ref msg);
    }
