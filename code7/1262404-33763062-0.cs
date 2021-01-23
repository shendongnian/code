    public static class MkpHelpers
    {
      public static HtmlString Urls(this HtmlHelper helper, string value)
      {
        var items = value.Split(';'); // use your delimiter
        var sb = new StringBuilder();
        foreach (var i in items)
        {
            var linkBuilder = new TagBuilder("a");
            linkBuilder.MergeAttribute("href",i);
            linkBuilder.InnerHtml = i;
            sb.Append(linkBuilder.ToString());
        }
        return new HtmlString(sb.ToString());
      }
    }
