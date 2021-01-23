    public static class BooleanDropdownListForHelper
    {
        public static MvcHtmlString BooleanDropdownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> property)
        {
            return BooleanDropdownListFor(htmlHelper, property, null);
        }
        public static MvcHtmlString BooleanDropdownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property, object htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(property, htmlHelper.ViewData);
            bool? value = null;
            if (metadata != null && metadata.Model != null)
            {
                if (metadata.Model is bool)
                    value = (bool)metadata.Model;
                else if (metadata.Model.GetType() == typeof(bool?))
                    value = (bool?)metadata.Model;
            }
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem() { Text = BooleanTypeFor.Yes, Value = "True", Selected = (value.HasValue && value.Value == true) },
                new SelectListItem() { Text = BooleanTypeFor.No, Value = "False", Selected = (value.HasValue && value.Value == false) }
            };
            return htmlHelper.DropDownListFor(property, items, htmlAttributes ?? new { });
        }
    }
