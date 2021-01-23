    public class ExtendedSelectListItem : SelectListItem
    {
        public Object htmlAttributes { get; set; }
    }
    public class CustomHtmlHelper
    {
        // taken from stackoverflow.com/a/7772354: requires by HTML helper to get model state
        public static Object GetModelStateValue(HtmlHelper helper, String key, Type destinationType)
        {
            ModelState state;
            if (helper.ViewData.ModelState.TryGetValue(key, out state))
            {
                if (state.Value != null)
                {
                    return state.Value.ConvertTo(destinationType, CultureInfo.InvariantCulture);
                }
            }
            return null;
        }
        // this part inspired from stackoverflow.com/a/7537628
        public static MvcHtmlString DropDownListForId<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<ExtendedSelectListItem> selectList, String optionLabel, Object htmlAttributes = null)
        {
            String name = ExpressionHelper.GetExpressionText(expression);
            String fullName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("Name is undefined");
            }
            if (selectList == null)
            {
                throw new ArgumentException("Select list is empty");
            }
            Object defaultValue = GetModelStateValue(helper, fullName, typeof(String));
            if (defaultValue == null) 
            {
                defaultValue = helper.ViewData.Eval(fullName);
            }
            else
            {
                var defaultValues = new[] { defaultValue };
                IEnumerable<String> listvalues = (from value in defaultValues select value.ToString();
                var selectedValues = new HashSet<String>(listvalues, StringComparer.OrdinalIgnoreCase);
                var newSelectList = new List<ExtendedSelectListItem>();
                foreach (ExtendedSelectListItem item in selectList)
                {
                    item.Selected = (item.Value != null) ? selectedValues.Contains(item.Value) : selectedValues.Contains(item.Text);
                    newSelectList.Add(item);
            }
            selectList = newSelectList;
            }
            var listItems = new StringBuilder();
            foreach (ExtendedSelectListItem item in selectList)
            {
                listItems.Append(ListItemToOption(item));
            }
            var tagBuilder = new TagBuilder("select")
            {
                InnerHtml = listItems.ToString()
            };
            tagBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            tagBuilder.MergeAttribute("name", fullName, true);
            tagBuilder.GenerateId(fullName);
            ModelState state;
            if (helper.ViewData.ModelState.TryGetValue(fullName, out state))
            {
                if (state.Errors.Count > 0)
                {
                   tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                }
            }
            tagBuilder.MergeAttributes(helper.GetUnobtrusiveValidationAttributes(name));
            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }
        public static String ListItemToOption(ExtendedSelectListItem item)
        {
            var builder = new TagBuilder("option")
            {
                InnerHtml = HttpUtility.HtmlEncode(item.Text)
            };
            if (item.Value != null)
            {
                builder.Attributes["value"] = item.Value;
                builder.Attributes["id"] = item.Value;
            }
            if (item.Selected)
            {
                builder.Attributes["selected"] = "selected";
            }
            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(item.htmlAttributes));
            return builder.ToString(TagRenderMode.Normal);
        }
    }
