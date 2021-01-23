    public static MvcHtmlString ValidationMessageFluent<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, int? itemIndex = null)
    {
    	List<ValidationFailure> validationFailures = html.ViewData["ValidationFailures"] as List<ValidationFailure>;
    	string exprMemberName = ((MemberExpression)expression.Body).Member.Name;
    	var priorityFailures = validationFailures.Where(f => f.PropertyName.EndsWith(exprMemberName));
    
    	if (priorityFailures.Count() == 0)
    	{
    		return null;
    	}
    
    	// Property name in 'validationFailures' may also be stored like this 'SomeRecords[0].PropertyName'
    	string propertyName = itemIndex.HasValue ? $"[{itemIndex}].{exprMemberName}" : exprMemberName;
    
    	// There can be multiple messages for one property
    	List<TagBuilder> tags = new List<TagBuilder>();
    	foreach (var validationFailure in priorityFailures.ToList())
    	{
    		if (validationFailure.PropertyName.EndsWith(propertyName))
    		{
    			TagBuilder span = new TagBuilder("span");
    			string customState = validationFailure.CustomState?.ToString();
    
    			// Handling the message type and adding class attribute
    			if (string.IsNullOrEmpty(customState))
    			{
    				span.AddCssClass(string.Format("field-validation-error"));
    			}
    			else if (customState == ValidationTypeEnum.Warning.ToString())
    			{
    				span.AddCssClass(string.Format("field-validation-warning"));
    			}
    
    			// Adds message itself to the html element
    			span.SetInnerText(validationFailure.ErrorMessage);
    			tags.Add(span);
    		}
    	}
    
    	StringBuilder strB = new StringBuilder();
    	// Join all html tags togeather
    	foreach(var t in tags)
    	{
    		strB.Append(t.ToString());
    	}
    
    	return MvcHtmlString.Create(strB.ToString());
    }
