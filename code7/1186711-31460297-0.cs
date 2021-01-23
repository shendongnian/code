    public static class HtmlHelperExtensions
    {
        public static IHtmlString JsonFor<TModel>(this HtmlHelper<TModel> helper, TModel model)
        {
            return JsonFor(helper, model, Formatting.None);
        }
        public static IHtmlString JsonFor<TModel>(this HtmlHelper<TModel> helper, TModel model, Formatting formatting)
        {
            string jsonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = formatting
            });
            return new HtmlString(jsonModel);
        }
    }
