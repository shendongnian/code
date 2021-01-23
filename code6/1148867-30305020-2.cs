    internal static MvcHtmlString LabelHelper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName, string labelText = null, IDictionary<string, object> htmlAttributes = null)
    {
          string resolvedLabelText = labelText ?? metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
          if (String.IsNullOrEmpty(resolvedLabelText))
          {
               return MvcHtmlString.Empty;
          }
    
          TagBuilder tag = new TagBuilder("label");
          tag.Attributes.Add("for", TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
          tag.SetInnerText(resolvedLabelText);
          tag.MergeAttributes(htmlAttributes, replaceExisting: true);
          return tag.ToMvcHtmlString(TagRenderMode.Normal);
    }
