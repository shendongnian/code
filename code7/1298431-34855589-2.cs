    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    public static class Extensions
    {
        public static MvcHtmlString CreateDropDownList<T>(this HtmlHelper helper, IEnumerable<T> list, string name,
            T selectedT, string dataValue, string dataText)
        {
            return helper.DropDownList(name, new SelectList(list, dataValue, dataText, selectedT));
        }
    }
