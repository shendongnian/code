    public static class ValidationExtensions
        {
                public static MvcHtmlString MyValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                    Expression<Func<TModel, TProperty>> expression)
                {
                    var propertyName = ExpressionHelper.GetExpressionText(expression);
                    var fullName = htmlHelper.AttributeEncode(htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(propertyName));
        
                    var isInvalid = htmlHelper.HasModelStateErros(expression);
        
                    var errors = string.Empty;
        
                    if (isInvalid)
                    {
                        foreach (var error in htmlHelper.ViewData.ModelState[fullName].Errors)
                        {
                            //add error message 
                            errors += error.ErrorMessage;
                            break;
                        }
                    }
        
                    return MvcHtmlString.Create(errors);
                }
        }
