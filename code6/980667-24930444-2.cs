    protected void linkButtonTag_Click(object sender, EventArgs e)
    {
    	LinkButton hyperLinkTag = sender as LinkButton;
    	if (Page is ITagable)
    		(Page as ITagable).Tag = hyperLinkTag.Text;
    			
    }
