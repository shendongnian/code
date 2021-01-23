        const int WM_TECH_BROKENLINE = 0x0401;  // It's WM_USER + 1 in my example.
                                                // Set it according to you dll's spec
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_TECH_BROKENLINE)
            {
                    long dataPassedFromTheDll = (long)m.WParam;
                    // Your stuff here:
                    this.Text = string.Format("The dll sent us: {0}", dataPassedFromTheDll);
            } 
            base.WndProc(ref m);
        }
