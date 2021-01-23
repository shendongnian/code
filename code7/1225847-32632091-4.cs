    public class CustomFlowLayout : FlowLayoutPanel
    {
    	public CustomFlowLayout()
    	{
    		//Do things here!
    	}
    
    	public int MyCustomProperty { get; set; }
    
        //Not needed to make anything work, added to show the code is working
    	protected override void OnPaint(PaintEventArgs e)
    	{
    		base.OnPaint(e);
    		StringFormat format = new StringFormat()
    		{
    			LineAlignment = StringAlignment.Center,
    			Alignment = StringAlignment.Center
    		};
    
    		e.Graphics.DrawString("It works! Wooooo..!", 
    			SystemFonts.DefaultFont, 
    			SystemBrushes.ControlText, 
    			new Rectangle(0, 0, this.Width, this.Height), 
    			format);
    	}
    }
