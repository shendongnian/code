	public static IDisposable BeginOptionalWrap(this HtmlHelper helper, string tag, bool test, object htmlAttributes = null)
	{
		var tb = new TagBuilder(tag);
		var attrs = GetAttributes(htmlAttributes);
		if (attrs != null)
		{
			tb.MergeAttributes(attrs);
		}
		if (test)
		{
			helper.ViewContext.Writer.Write(tb.ToString(TagRenderMode.StartTag));
		}
		return new OptionalWrap(helper, tb, test);
	}
	
