    private static void MarkListItemsSelected(string param, IList<SelectListItem> items)
    {
        var filters = param.ToUpper().Split(';');
        items.ToList()
             .ForEach(x => { x.Selected = filters.Contains(x.Text.ToUpper());});
    }
