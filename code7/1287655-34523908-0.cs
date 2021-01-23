    frmSecQStatToolTipDlg tooltip;
    
    private void B_MouseHover(object sender, EventArgs e)
    {
    	if(frmSecQStatToolTipDlg == null)
    	{
    		tooltip = new frmSecQStatToolTipDlg();
    	}
    	
    	tooltip.Location = this.PointToScreen(new Point(this.Left, this.Bottom));
    	tooltip.Show();
    }
    
    private void B_MouseLeave(object sender, EventArgs e)
    {
    	if(frmSecQStatToolTipDlg != null)
    	{
    		frmSecQStatToolTipDlg.Hide();
    	}
    }
