    if (!string.IsNullOrEmpty(originalQueryString))
    {
       var request = HttpContext.Current.Request;
       request.GetType().InvokeMember("QueryStringText", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, request, new[] { "q=" + originalQueryString });
       //WebFunction.CreateQuerystring(HttpContext.Current, WebFunction.ConvertQueryToCollection(originalQueryString));
    }
