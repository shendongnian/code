    public static class HtmlExtensions
    {
    	public static MvcHtmlString VisibleLabelFor<TModel, TResult>(this HtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression)
    	{
    		var type = expression.Body.NodeType;
    
    		if (type == ExpressionType.MemberAccess)
    		{
    			var memberExpression = (MemberExpression) expression.Body;
    			var p = memberExpression.Member as PropertyInfo;
    
    			if (!Attribute.IsDefined(p, typeof (VisibleAttribute)))
    				return new MvcHtmlString(string.Empty);
    
    			return html.LabelFor(expression);
    		}
    	}
    }
