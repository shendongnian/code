    public static IHtmlContent RenderIntegerInput<T>(CustomizableConfig<T> model, Func<T, TParam> func, string id, string name, int minValue, int maxValue)
    {
       //...
       string oldStringResult = ... // generating HTML
       return new HtmlEncodedString(oldStringResult);
    }
