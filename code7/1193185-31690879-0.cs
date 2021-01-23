    public static MvcHtmlString TextBoxForFilterDictionary(this HtmlHelper helper, IDictionary<string, FilterObject> filters, string fieldName, object htmlAttributes = null)
        {
            FilterObject filter;
            if (!filters.TryGetValue(fieldName, out filter))
            {
                filter = new FilterObject();
            }
            string nameAttribute = String.Format("Model.Filters[{0}].Filter", fieldName);
            MvcHtmlString html = helper.TextBox(nameAttribute, filter.Filter, htmlAttributes);
            return html;
        }
