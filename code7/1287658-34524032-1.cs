    frmSecQStatToolTipDlg f_tooltip;
    private void B_MouseHover(object sender, EventArgs e)
    {
        if(frmSecQStatToolTipDlg == null)
        {
            f_tooltip = new frmSecQStatToolTipDlg();
        }
    
        tooltip.Location = this.PointToScreen(new Point(this.Left, this.Bottom));
        tooltip.Show();
    }
    private void B_MouseLeave(object sender, EventArgs e)
    {
        if(f_tooltip != null)
        {
            f_tooltip.Close();
            f_tooltip = null;
        }
    }
