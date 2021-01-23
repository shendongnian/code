    private static void MarkListItemsSelected(string param, IList<SelectListItem> items)
    {
        var filters = param.ToUpper().Split(';');
        foreach( var x in items ) {
            x.Selected = filters.Contains(x.Text.ToUpper());
        }
    }
