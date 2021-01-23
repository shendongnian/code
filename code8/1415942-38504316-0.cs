    public IEnumerable<SelectListItem> GetCategoriesSelectList()
    {
        return _context.Category
             .Select(s => new SelectListItem
             {
                 Value = s.Id.ToString(),
                 Text = s.Name
             }).ToList().Add(new SelectListItem() { Text="all",Value="0" });
    }
