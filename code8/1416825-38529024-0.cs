    namespace WebFrontend.Utils
    {
        using System;
        using System.Linq.Expressions;
        using System.Web.Mvc;
        public static class WebExtensions
        {
            public static MvcHtmlString DisplayFor<TModel>(this HtmlHelper<TModel> html,
                Expression<Func<TModel, bool>> expression)
            {
                return html.DisplayFor(expression.Compile().Invoke(html.ViewData.Model));
            }
        }
    }
