    private static MvcHtmlString CheckBoxHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, bool? isChecked, IDictionary<string, object> htmlAttributes)
            {
                RouteValueDictionary attributes = ToRouteValueDictionary(htmlAttributes);
    
                bool explicitValue = isChecked.HasValue;
                if (explicitValue)
                {
                    attributes.Remove("checked"); // Explicit value must override dictionary
                }
    
                return InputHelper(htmlHelper,
                                   InputType.CheckBox,
                                   metadata,
                                   name,
                                   value: "true",
                                   useViewData: !explicitValue,
                                   isChecked: isChecked ?? false,
                                   setId: true,
                                   isExplicitValue: false,
                                   format: null,
                                   htmlAttributes: attributes);
            }
