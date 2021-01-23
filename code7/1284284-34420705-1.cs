    //this.DoubleBuffered = true; //doesn't work
    protected override CreateParams CreateParams { //Very important to cancel flickering effect!!
      get {
        CreateParams cp = base.CreateParams;
        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        //cp.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN not a good idea when combined with above. Not tested alone
        return cp;
      }
    }
