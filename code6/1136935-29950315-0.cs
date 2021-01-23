    public void lbSave1_Click(object sender, EventArgs e)
    {
    	customAlertDisplay.RemoveClass("hideTag");
    	upTaskInfo.Update();
    }
    
    public static class CE
    {
    	public static void RemoveClass(this HtmlControl control, string cssClassName)
    	{
    		var val = control.Attributes["class"];
    		val = val.Replace(cssClassName, string.Empty);
    		control.Attributes["class"] = val;
    	}
    }
