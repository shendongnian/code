    private static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, ModelMetadata metadata, string optionLabel, string name, IEnumerable<SelectListItem> selectList, bool allowMultiple, IDictionary<string, object> htmlAttributes)
    {
        string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
    
        // ...
    
        bool usedViewData = false;
    
        // If we got a null selectList, try to use ViewData to get the list of items.
        if (selectList == null)
        {
            selectList = htmlHelper.GetSelectData(name);
            usedViewData = true;
        }
    
        object defaultValue = (allowMultiple) ? htmlHelper.GetModelStateValue(fullName, typeof(string[])) : htmlHelper.GetModelStateValue(fullName, typeof(string));
    
        // If we haven't already used ViewData to get the entire list of items then we need to
        // use the ViewData-supplied value before using the parameter-supplied value.
        if (defaultValue == null && !String.IsNullOrEmpty(name))
        {
            if (!usedViewData)
            {
                defaultValue = htmlHelper.ViewData.Eval(name);
            }
            else if (metadata != null)
            {
                defaultValue = metadata.Model;
            }
        }
    
        if (defaultValue != null)
        {
            selectList = GetSelectListWithDefaultValue(selectList, defaultValue, allowMultiple);
        }
    
        // ...
    }
