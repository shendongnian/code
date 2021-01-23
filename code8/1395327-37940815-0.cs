    private static IEnumerable<SelectListItem> GetSelectData(this HtmlHelper htmlHelper, string name)
    {
        object o = null;
        if (htmlHelper.ViewData != null)
        {
            o = htmlHelper.ViewData.Eval(name);
        }
        if (o == null)
        {
            throw new InvalidOperationException(
                String.Format(
                    CultureInfo.CurrentCulture,
                    MvcResources.HtmlHelper_MissingSelectData,
                    name,
                    "IEnumerable<SelectListItem>"));
        }
        // ...
        return selectList;
    }
