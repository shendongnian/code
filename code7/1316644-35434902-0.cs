    protected override void OnSelectedIndexChanged(EventArgs e)
    {
    	base.OnSelectedIndexChanged(e);
    	if (Focused)
    	{
    		Parent.Focus();
    	}
    }
