    public static MvcHtmlString AddressEditorForModel<TModel>(this HtmlHelper<TModel> helper, string prefix, bool showLabels)
    {          
        // There will be more markup in here, this is just slimmed down..
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(String.Format("<div id='{0}_AddressContainer' >", prefix));
             //Create a parameter expression for the model type
             ParameterExpression paramExpr = Expression.Parameter(typeof (TModel));
             //Loop through the properties you want to create a DisplayFor for
             foreach (var property in typeof (TModel).GetProperties())
             {
                 //Create a member access expression for accessing this property
                 MemberExpression propertyAccess = Expression.MakeMemberAccess(paramExpr, property);
                 //Create the lambda expression (eg. "x => x.Name")
                 var lambdaExpr = Expression.Lambda<Func<TModel, string>>(propertyAccess, paramExpr);
                 //Pass this lambda to the DisplayFor method
                 sb.AppendLine(helper.DisplayFor(lambdaExpr).ToString());
             }
    ...rest of your method
