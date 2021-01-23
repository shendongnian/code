    public static MvcHtmlString HelpTextFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expr)
    {
        var memberExpr = expr.Body as MemberExpression;
        if (memberExpr != null)
        {
            var helpAttr = memberExpr.Member.GetCustomAttributes(false).OfType<HelpTextAttribute>().SingleOrDefault();
            if (helpAttr != null)
                return new MvcHtmlString(@"<span class=""help"">" + helpAttr.Text + "</span>");
        }
        return MvcHtmlString.Empty;
    }
