    public static class HtmlExtensions
    {
        public static IHtmlString HiddenFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IFormatProvider formatter)
        {
            var value = expression.Compile().Invoke(helper.ViewData.Model);
            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var property = typeof(TModel).GetProperty(modelMetadata.PropertyName);
            var attribute = property.GetCustomAttributes(typeof(DisplayFormatAttribute), false).SingleOrDefault() as DisplayFormatAttribute;
            
            var displayValue = String.Format(formatter, attribute?.DataFormatString ?? "{0}", value);
            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttribute("type", "hidden");
            tagBuilder.MergeAttribute("value", displayValue);
            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }
