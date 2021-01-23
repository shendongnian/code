    namespace CustomHelpers
    {
      public static class HtmlHelperExtensions
      {
        public static MvcHtmlString CustomTextBox(this HtmlHelper htmlHelper, string name, string value)
        {
          var builder = new TagBuilder("input");
          builder.MergeAttribute("type", "text");
          builder.MergeAttribute("name", name);
          builder.MergeAttribute("value", value);
          return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
      }
    }
