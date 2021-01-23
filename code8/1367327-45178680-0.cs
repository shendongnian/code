    public static class KendoExtensions
    {
        public static GridTemplateColumnBuilder<TModel> DestroyConditional<TModel>(this GridColumnFactory<TModel> factory, Expression<Func<TModel, bool>> expression)
            where TModel : class
        {
            var template = "# if (" + ExpressionHelper.GetExpressionText(expression) +") { # <a class=\"k-button k-button-icontext k-grid-delete\"><span class=\"k-icon k-delete\"></span>" + TextStrings.Delete + "</a># } #";
    
            return factory.Template(e => "").ClientTemplate(template).Title("");
        }
    }
