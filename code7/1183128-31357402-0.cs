         public static MvcHtmlString DisplayResourceFor<TModel, TValue>(this HtmlHelper<TModel> helper, 
            Expression<Func<TModel, TValue>> expression)
        {
            var rm = new ResourceManager("Resources.Global", 
                System.Reflection.Assembly.Load("App_GlobalResources"));
            var resource = rm.GetString(string.Format("{0}Resource", 
                ExpressionHelper.GetExpressionText(expression)));
            var value = helper.ViewContext.ViewData.GetViewDataInfo(resource).Value.ToString();
            return MvcHtmlString.Create(value);
        }
