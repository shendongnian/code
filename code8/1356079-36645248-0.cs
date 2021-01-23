    public static MvcHtmlString DatePickerFor<TModel, TProperty>
    (this HtmlHelper<TModel> helper, 
    Expression<Func<TModel, TProperty>> expression)
    {
        string datePickerName = 
              ExpressionHelper.GetExpressionText(expression);
        string datePickerFullName = helper.ViewContext.ViewData.
                       TemplateInfo.GetFullHtmlFieldName
                       (datePickerName);
        string datePickerID = TagBuilder.CreateSanitizedId
                              (datePickerFullName);
    
        ModelMetadata metadata = ModelMetadata.FromLambdaExpression
                                 (expression, helper.ViewData);
        DateTime datePickerValue = (metadata.Model == null ? 
                                 DateTime.Now : DateTime.Parse(
                                 metadata.Model.ToString()));
    
        TagBuilder tag = new TagBuilder("input");
        tag.Attributes.Add("name", datePickerFullName);
        tag.Attributes.Add("id", datePickerID);
        tag.Attributes.Add("type", "date");
        tag.Attributes.Add("value", datePickerValue.
                                    ToString("yyyy-MM-dd"));
    
        IDictionary<string, object> validationAttributes = helper.
        GetUnobtrusiveValidationAttributes
        (datePickerFullName, metadata);
    
        foreach (string key in validationAttributes.Keys)
        {
            tag.Attributes.Add(key, validationAttributes[key].ToString());
        }
    
        MvcHtmlString html=new MvcHtmlString(
                   tag.ToString(TagRenderMode.SelfClosing));
        return html;
    }
  
