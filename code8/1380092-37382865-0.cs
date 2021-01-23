    public static class Extensions
    {
    	public static string ToXPath(this HtmlNode node)
    	{
    		var attributes = node.Attributes.Any() ? "[" + string.Join(" and ", node.Attributes.Select(o => "@" + o.Name + "='" + o.Value + "'")) + "]" : "";
    		var xpath = "//" + node.Name + attributes;
    		return xpath;
    	}
    }
