    <!-- language: lang-csharp -->
        using System.Web.Mvc;
        using System.Web.Mvc.Html;
        namespace Project.Helpers
        {
            public static class HtmlHelper
            {
                public static bool HasValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
                {
                    var value = htmlHelper.ValidationMessageFor(expression).ToString();
                    return value.Contains("field-validation-error");
                }
            }
        }
