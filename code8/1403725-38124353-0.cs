    View Model:
            [Display(Name = "Which Credit Cards are Accepted:")]
            public string[] CreditCards { get; set; }
    
    	Helper:
            public static HtmlString CheckboxGroup<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> propertySelector, Type EnumType)
            {
                var groupName = GetPropertyName(propertySelector);
                var modelValues = ModelMetadata.FromLambdaExpression(propertySelector, htmlHelper.ViewData).Model;//propertySelector.Compile().Invoke(htmlHelper.ViewData.Model);
            StringBuilder literal = new StringBuilder();  
            foreach (var value in Enum.GetValues(EnumType))
            {
                var svalue = value.ToString();
                var builder = new TagBuilder("input");
                builder.GenerateId(groupName);
                builder.Attributes.Add("type", "checkbox");
                builder.Attributes.Add("name", groupName);
                builder.Attributes.Add("value", svalue);
                var contextValues = HttpContext.Current.Request.Form.GetValues(groupName);
                if ((contextValues != null && contextValues.Contains(svalue)) || (modelValues != null && modelValues.ToString().Contains(svalue)))
                {
                    builder.Attributes.Add("checked", null);
                }
                literal.Append(String.Format("</br>{1}&nbsp;<span>{0}</span>", svalue.Replace('_', ' '),builder.ToString(TagRenderMode.Normal)));
            }
            return (HtmlString)htmlHelper.Raw(literal.ToString()); 
        }
        private static string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> propertySelector)
        {
            var body = propertySelector.Body.ToString();
            var firstIndex = body.IndexOf('.') + 1;
            return body.Substring(firstIndex);
        }
