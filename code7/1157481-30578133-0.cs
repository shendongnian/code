    private bool userResizing = false;
    protected override void WndProc(ref Message m) {
      const int wmNcHitTest = 0x84;
      const int htBottomLeft = 16;
      const int htBottomRight = 17;
      const int WM_EXITSIZEMOVE = 0x232;
      const int WM_NCLBUTTONDWN = 0xA1;
      if (m.Msg == WM_NCLBUTTONDWN) {
        if (!userResizing) {
          userResizing = true;
          Console.WriteLine("Start Resizing");
        }
      } else if (m.Msg == WM_EXITSIZEMOVE) {
        if (userResizing) {
          userResizing = false;
          Console.WriteLine("Finish Resizing");
        }
      } else if (m.Msg == wmNcHitTest) {
        int x = (int)(m.LParam.ToInt64() & 0xFFFF);
        int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
        Point pt = PointToClient(new Point(x, y));
        Size clientSize = ClientSize;
        if (pt.X >= clientSize.Width - 16 && 
            pt.Y >= clientSize.Height - 16 &&
            clientSize.Height >= 16) {
          m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
          return;
        }
      }
      base.WndProc(ref m);
    }
