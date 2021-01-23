      public static MvcHtmlString TruncateDropDown(this HtmlHelper helper, string name, ListItem[] values, Dictionary<string, object> htmlAttributes)
            {
    
                List<SelectListItem> Textes = new List<SelectListItem>();
                foreach (ListItem item in values)
                {
                    SelectListItem selItem = new SelectListItem();
                    if (item.Text.Length <= 20) selItem.Text = item.Text;
                    else selItem.Text = item.Text.Substring(0, 20) + "...";
                    Textes.Add(selItem);
                }
    
                return System.Web.Mvc.Html.SelectExtensions.DropDownList(helper,name, Textes,  htmlAttributes);
    
            }
