    public static class Util
    {
    	public static string GetCrossPageValue(this Page page)
    	{
    		if (page == null || page.Master == null) return null;
    		var hf = page.Master.FindControl("hdCrossPageValue") as HiddenField;
    		return hf == null ? null : hf.Value;
    	}
    	public static void SetCrossPageValue(this Page page, string value)
    	{
    		if (page == null || page.Master == null) return;
    		var hf = page.Master.FindControl("hdCrossPageValue") as HiddenField;
    		if (hf != null)
    		{
    			hf.Value = value;
    		}
    	}
    }
