      public static MvcHtmlString DropDownListFor<TModel, TProperty>(
                this HtmlHelper<TModel> htmlHelper,
                Expression<Func<TModel, TProperty>> expression,
                List<dynamic> selectedValue)
            {
                               var items = from value in selectedValue
                            select new SelectListItem()
                            {
                                Text = value.ToString(),
                                Value = value.ToString()
                            };
                return htmlHelper.DropDownListFor(expression, items);
            }
