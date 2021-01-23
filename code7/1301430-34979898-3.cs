    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString EditorForMany<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, IEnumerable<TValue>>> propertyExpression, Expression<Func<TValue, string>> indexResolverExpression = null, string htmlFieldName = null) where TModel : class
        {
            htmlFieldName = htmlFieldName ?? ExpressionHelper.GetExpressionText(propertyExpression);
            var items = propertyExpression.Compile()(html.ViewData.Model);
            var htmlBuilder = new StringBuilder();
            var htmlFieldNameWithPrefix = html.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            Func<TValue, string> indexResolver = null;
            if (indexResolverExpression == null)
            {
                indexResolver = x => null;
            }
            else
            {
                indexResolver = indexResolverExpression.Compile();
            }
                        
            foreach (var item in items)
            {
                var dummy = new { Item = item };
                var guid = indexResolver(item);
                var memberExp = Expression.MakeMemberAccess(Expression.Constant(dummy), dummy.GetType().GetProperty("Item"));
                var singleItemExp = Expression.Lambda<Func<TModel, TValue>>(memberExp, propertyExpression.Parameters);
                if (String.IsNullOrEmpty(guid))
                {
                    guid = Guid.NewGuid().ToString();
                }
                else
                {
                    guid = html.AttributeEncode(guid);
                }
                htmlBuilder.Append(String.Format(@"<input type=""hidden"" name=""{0}.Index"" value=""{1}"" />", htmlFieldNameWithPrefix, guid));
                if (indexResolverExpression != null)
                {
                    htmlBuilder.Append(String.Format(@"<input type=""hidden"" name=""{0}[{1}].{2}"" value=""{1}"" />", htmlFieldNameWithPrefix, guid, ExpressionHelper.GetExpressionText(indexResolverExpression)));
                }
                htmlBuilder.Append(html.EditorFor(singleItemExp, null, String.Format("{0}[{1}]", htmlFieldName, guid)));
            }
            return new MvcHtmlString(htmlBuilder.ToString());
        }
    }
