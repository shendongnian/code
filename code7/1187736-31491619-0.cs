    public class ControlColor
    {
    	private Color _setBColor = Color.FromArgb(255, 255, 0);
    	private Color _setFColor = SystemColors.ControlText;
    
    	public ControlColor(params Control[] ctls)
    	{
    		foreach (Control ctr in ctls)
    		{
    			ctr.Enter += new EventHandler(onEnter);
    			ctr.Leave += new EventHandler(onLeave);
    		}
    	}
    	public ControlColor(Color bkg, Color frg, params Control[] ctls)
    	{
    		_setFColor = frg;
    		_setBColor = bkg;
    		foreach (Control ctr in ctls)
    		{
    			ctr.Enter += new EventHandler(onEnter);
    			ctr.Leave += new EventHandler(onLeave);
    		}
    	}
    
    	private void onEnter(object sender, EventArgs e)
    	{
    		if (sender is Control)
    		{
    			Control ctr = (Control)sender;
    			ctr.BackColor = _setBColor;
    			ctr.ForeColor = _setFColor;
    		}
    
    	}
    	private void onLeave(object sender, EventArgs e)
    	{
    		Control ctr = sender as Control;
    		ctr.BackColor = SystemColors.Window;
    		ctr.ForeColor = SystemColors.ControlText;
    	}
    }
