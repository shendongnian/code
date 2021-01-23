    public static MvcHtmlString TextboxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
    {
        var dict = new RouteValueDictionary(htmlAttributes ?? new object { });
    	var tag = new TagBuilder("span");//default view
    	if((bool) helper.ViewContext.Controller.ViewBag.CanEdit){//edit view
    		tag = new TagBuilder("input");
    		tag.Attributes.Add("class", "form-control");
    		if (!dict.ContainsKey("type"))
    		{
    			tag.Attributes.Add("type", "text");//default input type
    		}
    	}else
    	{
    	    var value = ModelMetadata.FromLambdaExpression(
    	        expression, helper.ViewData
    	        ).Model;
    	    tag.InnerHtml = value.ToString();
    	}
        return BaseNode(helper, expression, tag, TagRenderMode.SelfClosing, dict);
    }
    public static MvcHtmlString BaseNode<TModel, TProperty>(HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, TagBuilder tag, TagRenderMode tagRenderMode, RouteValueDictionary dict)
    {
        var name = ExpressionHelper.GetExpressionText(expression);
        var fullName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
        var id = TagBuilder.CreateSanitizedId(fullName);
        var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
    
    
        tag.Attributes.Add("name", fullName);
        tag.Attributes.Add("id", id);
    
        foreach (var dKey in dict.Keys)
        {
            var value = dict[dKey].ToString();
            var key = dKey.Replace("_", "-");
            tag.Attributes.Add(key, value);
        }
    
    
        return new MvcHtmlString(tag.ToString(tagRenderMode));
    }
