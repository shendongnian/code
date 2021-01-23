    public static IList<SelectListItem> ToSelectList<T>(this IEnumerable<T> itemsToMap, Func<T, string> textProperty, Func<T, string> valueProperty, Predicate<T> isSelected)
    {
        var result = new List<SelectListItem>();
    
        foreach (var item in itemsToMap)
        {
            result.Add(new SelectListItem
            {
                Value = valueProperty(item),
                Text = textProperty(item),
                Selected = isSelected(item)
            });
        }
        return result;
    }
