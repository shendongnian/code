     private static MvcHtmlString InputHelper(HtmlHelper htmlHelper, InputType inputType, ModelMetadata metadata, string name, object value, bool useViewData, bool isChecked, bool setId, bool isExplicitValue, string format, IDictionary<string, object> htmlAttributes)
            {
                string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
                if (String.IsNullOrEmpty(fullName))
                {
                    throw new ArgumentException(MvcResources.Common_NullOrEmpty, "name");
                } 
              ... 
             }
