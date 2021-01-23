    private static void MarkListItemsSelected(string param, IList<SelectListItem> items)
    {
        var filters = param.ToUpper().Split(';');
        items.ToList()
             .Where(x => filters.Contains(x.Text.ToUpper()))
             .ForEach(x => { x.Selected = true });
    }
