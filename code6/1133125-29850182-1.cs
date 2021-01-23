    protected void TranslateToolTip(ToolTip toolTip)
    {
        foreach (var component in toolTip.Container.Components)
        { 
            // Doesn't work. No ToolTipText property
            // component.ToolTipText = Translate(component.ToolTipText);
               toolTip.SetToolTip(component , (string)Translate(toolTip.GetToolTip(component));
        }
    }
