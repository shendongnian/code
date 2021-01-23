    public static class Extensions
    {
        public static void DisplayNameFor(this HtmlHelper html, LambdaExpression e)
        {
            if(e.Parameters.Count != 1)
                throw new InvalidOperationException("Only lambdas of form Expression<Func<TModel, TValue>> are accepted.");
            //Gather type parameters
            var valueType = e.ReturnType;
            var modelType = e.Parameters[0].Type;
            //Get method with signature DisplayNameExtensions.DisplayNameFor<TModel, TValue>(this HtmlHelper<TModel>, Expression<Func<TModel,TValue>>)
            var methodinfos = typeof (DisplayNameExtensions).GetMethods()
                .Where(mi => mi.Name == "DisplayNameFor")
                .ToList();
            var methodInfo = methodinfos[1];
            //Construct generic method
            var generic = methodInfo.MakeGenericMethod(modelType, valueType);
            //invoke constructed generic method
            generic.Invoke(null, new object[] {html, e});
        }
    }
