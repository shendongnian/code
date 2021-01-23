    public static class HtmlHelpers {
        /// <summary>
        /// Extends MvcHtml to conditionaly display a value or empty string
        /// </summary>
        /// <param name="value">Value to be displayed if 'evaluation' is true</param>
        /// <param name="evaluation"></param>
        /// <returns></returns>
        public static MvcHtmlString If(this MvcHtmlString value, bool evaluation) {
            return evaluation ? value : MvcHtmlString.Empty;
        }
        /// <summary>
        /// Extends MvcHtml to conditionaly display one of two possible values
        /// </summary>
        /// <param name="value">Value to be displayed if 'evaluation' is true</param>
        /// <param name="evaluation"></param>
        /// <param name="valueIfFalse">Value to be displayed if 'evaluation' is false</param>
        /// <returns></returns>
        public static MvcHtmlString If(this MvcHtmlString value, bool evaluation, MvcHtmlString valueIfFalse) {
            return evaluation ? value : valueIfFalse;
        }
    }
    public static class AutocompleteHelpers
    {
        public static MvcHtmlString AutocompleteFor<TModel, TProperty1, TProperty2>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty1>> valueExpression,
            Expression<Func<TModel, TProperty2>> idExpression, string actionName, string controllerName, bool requestFocus)
        {
            return CreateTextBoxForFromAutocompleteFor<TModel, TProperty1, TProperty2>(html, valueExpression, actionName, controllerName, requestFocus,
                idExpression.Body.ToString());
        }
        public static MvcHtmlString AutocompleteFor<TModel, TProperty1, TProperty2>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty1>> valueExpression,
            Expression<Func<TModel, TProperty2>> idExpression, int index, string actionName, string controllerName, bool requestFocus)
        {
            // Get the fully qualified class name of the autocomplete id field
            string idFieldString = idExpression.Body.ToString();
            // handle if the id field is an array
            int loc_get_Item = idFieldString.IndexOf(".get_Item(");
            if (loc_get_Item > 0)
            {
                idFieldString = idFieldString.Substring(0, loc_get_Item);
                idFieldString += string.Format("_{0}_", index);
            }
            var textBoxFor = CreateTextBoxForFromAutocompleteFor<TModel, TProperty1, TProperty2>(html, valueExpression, actionName, controllerName, requestFocus, idFieldString);
            return textBoxFor;
        }
        private static MvcHtmlString CreateTextBoxForFromAutocompleteFor<TModel, TProperty1, TProperty2>(HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty1>> valueExpression, string actionName, string controllerName, bool requestFocus, string idFieldString)
        {
            string autocompleteUrl = UrlHelper.GenerateUrl(null, actionName, controllerName,
                                                           null,
                                                           html.RouteCollection,
                                                           html.ViewContext.RequestContext,
                                                           includeImplicitMvcValues: true);
            string @class = "form-control typeahead" + (requestFocus ? " focus" : string.Empty);
            // We need to strip the 'model.' from the beginning
            int loc = idFieldString.IndexOf('.');
            // Also, replace the . with _ as this is done by MVC so the field name is js friendly
            string autocompleteIdField = idFieldString.Substring(loc + 1, idFieldString.Length - loc - 1).Replace('.', '_');
            var textBoxFor = html.TextBoxFor(valueExpression,
                new {data_autocomplete_url = autocompleteUrl, @class, data_autocomplete_id_field = autocompleteIdField});
            return textBoxFor;
        }
    }
