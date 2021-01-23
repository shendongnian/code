    internal static bool HasModelStateErrors<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
            {
                var propertyName = ExpressionHelper.GetExpressionText(expression);
                var name = helper.AttributeEncode(helper.ViewData.TemplateInfo.GetFullHtmlFieldName(propertyName));
                return helper.ViewData.ModelState[name] != null &&
                                helper.ViewData.ModelState[name].Errors != null &&
                                helper.ViewData.ModelState[name].Errors.Count > 0;
            }
