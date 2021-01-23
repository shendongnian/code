    public static MvcHtmlString EnumDropDownListFor<TModel, TProperty, TEnum>(
                    this HtmlHelper<TModel> htmlHelper,
                    Expression<Func<TModel, TProperty>> expression,
                    TEnum selectedValue)
                where TEnum : struct, IConvertible
            {
                var values = Enum.GetValues(typeof (TEnum))
                    .Cast<TEnum>().ToArray();
    
                var items = values
                    .Select(x => new
                    {
                        Text = x.ToString(CultureInfo.InvariantCulture),
                        Value = Convert.ChangeType(x, x.GetTypeCode()),
                        Selected = (x.Equals(selectedValue))
                    })
                    .Select(x => new SelectListItem
                {
                    Text = x.Text,
                    Value = x.Value == null
                        ? ""
                        : x.Value.ToString(),
                    Selected = x.Selected
                });
    
                return htmlHelper.DropDownListFor(expression, items);
            }
