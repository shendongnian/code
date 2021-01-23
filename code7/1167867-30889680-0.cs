	public static void HtmlHelperExtensions
	{
	     public static object GetPropertyValue(this HtmlHelper html, object src, string propName)
	     {
	         return src.GetType().GetProperty(propName).GetValue(src, null);
	     }
	}
