    protected override void WndProc(ref Message m)
    {
      if(m.Msg == 528 && !this.Focused)
      {
        this.Focus();
      }
      base.WndProc(ref m);
    }
