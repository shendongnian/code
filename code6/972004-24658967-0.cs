    public static MvcHtmlString AddressEditorForModel<TModel>(this HtmlHelper<TModel> helper, string prefix, bool showLabels)
    {          
        // There will be more markup in here, this is just slimmed down..
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(String.Format("<div id='{0}_AddressContainer' >", prefix));
             ParameterExpression paramExpr = Expression.Parameter(typeof (TModel));
             foreach (var property in typeof (TModel).GetProperties())
             {
                 MemberExpression propertyAccess = Expression.MakeMemberAccess(paramExpr, property);
                 var lambdaExpr = Expression.Lambda<Func<TModel, string>>(propertyAccess, paramExpr);
                 sb.AppendLine(helper.DisplayFor(lambdaExpr).ToString());
             }
    ...rest of your method
