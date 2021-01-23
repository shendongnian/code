           public static MvcHtmlString CheckBoxLabelFor<TModel>(this HtmlHelper<TModel> pHtml, Expression<Func<TModel, bool>> pExpression, IDictionary<string, Object> pLabelHtmlAttributes, string pCaption)
        {
            try
            {
                MvcHtmlString tCheckBox;
                string tCheckBoxWithLabel;
                TagBuilder tBuilder;
                tCheckBox = InputExtensions.CheckBoxFor(pHtml, pExpression);
                tBuilder = new TagBuilder("label");
                tBuilder.MergeAttributes(new RouteValueDictionary(pLabelHtmlAttributes));
                tCheckBoxWithLabel ="<a>" + tBuilder.ToString(TagRenderMode.StartTag) + tCheckBox.ToString() + pCaption + "</label></a>";
                return MvcHtmlString.Create(tCheckBoxWithLabel);
            }
            catch (Exception ex)
            {
                clsINFEventLogger.LogEvent(mdlEnumerations.INFEventTypes.Error, ex.Message, ex.StackTrace);
                return null;
            }
        }
