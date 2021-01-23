    using System;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    namespace YourAssembly.Html
    {
      public static class BootstrapHelper
      {
        public static MvcHtmlString BootstrapEditorFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {      
          MvcHtmlString label = LabelExtensions.LabelFor(helper, expression, new { @class = "control-label col-xs-12 col-sm-4 col-md-3" });
          MvcHtmlString editor = EditorExtensions.EditorFor(helper, expression, new { htmlAttributes = new { @class = "form-control" } });
          MvcHtmlString validation = ValidationExtensions.ValidationMessageFor(helper, expression, null, new { @class = "text-danger" });
          // Build the input elements
          TagBuilder editorDiv = new TagBuilder("div");
          editorDiv.AddCssClass("col-xs-4 col-sm-2 col-md-2 col-lg-1");
          editorDiv.InnerHtml = editor.ToString();
          // Build the validation message elements
          TagBuilder validationSpan = new TagBuilder("span");
          validationSpan.AddCssClass("help-block");
          validationSpan.InnerHtml = validation.ToString();
          TagBuilder validationDiv = new TagBuilder("div");
          validationDiv.AddCssClass("col-xs-12 col-md-8 col-sm-offset-4 col-md-offset-3");
          validationDiv.InnerHtml = validationSpan.ToString();
          // Combine all elements
          StringBuilder html = new StringBuilder();
          html.Append(label.ToString());
          html.Append(editorDiv.ToString());
          html.Append(validationDiv.ToString());
          // Build the outer div
          TagBuilder outerDiv = new TagBuilder("div");
          outerDiv.AddCssClass("form-group");
          outerDiv.InnerHtml = html.ToString();
          return MvcHtmlString.Create(outerDiv.ToString());
        }
      }
    }
