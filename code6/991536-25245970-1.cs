    private void frm_Load(object sender, EventArgs e)
    {
    	ctrl.MouseEnter += ctrl_MouseEnter;
    	ctrl.MouseLeave += ctrl_MouseLeave;
    }
    
    private bool bMouseInside = false;
    
    private void ctrl_MouseEnter(object sender, EventArgs e)
    {
    	bMouseInside = true;
    }
    
    private void ctrl_MouseLeave(object sender, EventArgs e)
    {
    	bMouseInside = false;
    }
