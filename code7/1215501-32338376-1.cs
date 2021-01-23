    private void YourFormName_Load(object sender, EventArgs e)
    {
         ContextMenu mnu = new ContextMenu();
         MenuItem mnuCopy = new MenuItem("Copy");
         mnuCopy.Click += (sen, ev) =>
         { 
             System.Windows.Forms.Clipboard.SetText(YourTextBoxName.Text);
         };
         mnu.MenuItems.AddRange(new MenuItem[] { mnuCopy });
         YourTextBoxName.ContextMenu = mnu;
    }
    private void YourFormName_MouseUp(object sender, MouseEventArgs e)
    {
        Control ctl = this.GetChildAtPoint(e.Location);
        if (ctl != null && !ctl.Enabled && ctl.ContextMenuStrip != null)
        ctl.ContextMenuStrip.Show(this, e.Location);
    }
