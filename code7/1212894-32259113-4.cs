    private static void MarkListItemsSelected(string param, IList<SelectListItem> items)
    {
        foreach( var filter in param.ToUpper().Split(';') ) {
            foreach( var item in items ) {
                item.Selected = item.Text.ToUpper() == filter;
            }
        }
    }
