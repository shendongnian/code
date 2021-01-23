    private static void MarkListItemsSelected(string param, IList<SelectListItem> items)
    {
        var filters = param.Split(';');
        filters.ToList().ForEach(
            x =>
            {
                var found = items.ToList().Find(y => y.Text.ToUpper().Equals(x.ToUpper()));
                if (found != null)
                    found.Selected = true;
            });
    }
