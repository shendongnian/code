    public DrawToolType ActiveTool
    {
    	get { return activeTool; }
    	set
    	{
    		if (activeTool == value) return;
    		if (activeTool == DrawToolType.Text)
    		{
    			alphaBlendTextBox txt = null;
    			foreach (var ctrl in Controls)
    			{
    				if (ctrl as alphaBlendTextBox!= null)
    				{
    					txt = (alphaBlendTextBox)ctrl;
    					break;
    				}
    			}
    
    			if (txt != null) ((ToolText)tools[(int)activeTool]).txt_Leave(txt, null);
    
    		}
    		activeTool = value;
    	}
    }
