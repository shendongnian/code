    protected void Page_PreRender(object sender, EventArgs e)
    {
    	var listSocialShare = FindControlsRecursive<SocialElement>(Page);
    	int number = listSocialShare.Count();
    }
    
    private IEnumerable<T> FindControlsRecursive<T>(Control root)
    {
    	foreach (Control child in root.Controls)
    	{
    		if (child is T)
    		{
    			yield return (T)Convert.ChangeType(child, typeof(T));
    		}
    
    		if (child.Controls.Count > 0)
    		{
    			foreach (T c in FindControlsRecursive<T>(child))
    			{
    				yield return c;
    			}
    		}
    	}
    }
