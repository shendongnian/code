    public static MvcHtmlString TaskTableFor<TModel, TValue>(this HtmlHelper<TModel> helper, 
      Expression<Func<TModel, TValue>> expression)
    {
      // Get the model metadata
      ModelMetadata metaData = ModelMetadata
        .FromLambdaExpression(expression, helper.ViewData);
      IEnumerable<string> items= metaData.Model as IEnumerable<string>;
      if (items == null || items.Count() != 2)
      {
        throw new ArgumentException("Invalid collection");
      }
      StringBuilder html = new StringBuilder();
      TagBuilder first = new TagBuilder("li");
      first.InnerHtml = items.First();
      html.Append(first.ToString());
      TagBuilder second = new TagBuilder("li");
      second.InnerHtml = items.Last();
      html.Append(second.ToString());
      TagBuilder list = new TagBuilder("ul");
      list.InnerHtml = html.ToString();
      return MvcHtmlString.Create(list.ToString());
    }
