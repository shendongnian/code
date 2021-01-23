    // DropDown helper
            public static MvcHtmlString DropDownInputFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> ListValues, string DefaultText, object HTMLAttributes, bool CanEdit)
            {            
                if (CanEdit == true)
                {
                    // return a dropdown
                    return htmlHelper.DropDownListFor(expression, ListValues, DefaultText, HTMLAttributes);
                }
                else
                {
                    // just return the text (no editor) 
                    //but first make sure you have a valid value in your list and show it               
                    var selected = ListValues.FirstOrDefault(item => item.Selected == true);
                    if (selected != null)
                        return htmlHelper.DisplayName(selected.Text);
                    else
                        //here you can just put the default selected item if no valid value is found
                        return htmlHelper.DisplayName(ExpressionHelper.GetExpressionText(expression));//or whatever defaultvalue you want 
                }
            }
