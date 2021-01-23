    namespace WebApplication1
    {
      public static class WebViewPageExtensions
      {
        public static IHtmlString _(this WebViewPage page, string msg)
        {
          return new HtmlString(msg);
        }
      }
    }
