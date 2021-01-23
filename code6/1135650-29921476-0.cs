    using Newtonsoft.Json;
    public static class JavascriptExtensions {
       public static IHtmlString AsJavascript<T>(this T value) where T: class{
          return MvcHtmlString.Create(JsonConvert.SerializeObject(value));
       }
    }
