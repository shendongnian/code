    public static class XmlUtils
    {
    	public static void SetInnerText(this XmlElement xmlElement, string text)
    	{
    		if(text != null)
    			xmlElement.InnerText = text;
    	}
    }
