    public static MvcHtmlString Article(this HtmlHelper helper, Article article)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"<h1>{article.Title}</h1>");
        sb.Append(helper.Partial(article.ViewName).ToHtmlString());
        return new MvcHtmlString(sb.ToString());
    }
