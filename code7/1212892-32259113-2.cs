    private static void MarkListItemsSelected(string param, IList<SelectListItem> items)
    {
        var filters = param.ToUpper().Split(';');
        items.Where(x => filters.Contains(x.Text.ToUpper()))
             .ToList()
             .ForEach(x => { x.Selected = true;});
    }
