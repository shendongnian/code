    private void ToggleView() {
      if (this.Visible) {
        this.Hide();
        notifyIcon.Visible = true;
        notifyIcon.BalloonTipText = "We got minimized";
        notifyIcon.Text = "Minimized";
        notifyIcon.ShowBalloonTip(1000);
      } else {
        this.Show();
        notifyIcon.Visible = false;
      }
    }
    protected override void WndProc(ref Message m) {
      const int WM_SYSCOMMAND = 0x0112;
      const int SC_MINIMIZE = 0xf020;
      if (m.Msg == WM_SYSCOMMAND) {
        if (m.WParam.ToInt32() == SC_MINIMIZE) {
          m.Result = IntPtr.Zero;
          ToggleView();
          return;
        }
      }
      base.WndProc(ref m);
    }
    public void button_click(object sender, EventArgs e) {
      ToggleView();
    }
    private void notifyIcon_MouseClick(object sender, MouseEventArgs e) {
      ToggleView();
    }
