    protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
    {
        ToolStrip owner = e.ToolStrip;
        while (owner is ToolStripDropDownMenu)
            owner = (owner as ToolStripDropDownMenu).OwnerItem.Owner;
        if (ts is MenuStrip)  
        {
        }
        else if (ts is StatusStrip)
        {
        }
        else  // ts is ToolStrip
        {
        }      
    }
