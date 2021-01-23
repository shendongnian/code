    public static class Extensions
    {
        public static string Localize(string exp)
        {
            var ret = exp;
            try
            {
                //try to apply localized version of exp, for example:
                ret = exp + "_Localized";
            }
            catch(Exception ex)
            { 
                //Log ex
            }
            return ret;
        }
        public static MvcHtmlString Localize(this HtmlHelper htmlhelper, string exp)
        {
            var ret = string.Format("<span class=\"localized\" title=\"{1}\">{0}</span>",
                                    exp, Localize(exp));
            return MvcHtmlString.Create(ret);
        }
    }
