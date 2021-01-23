    IEnumerable<SelectListItem> categories = new List<SelectListItem>
    {
        Value = "0",
        Text = "All"
    }.Concat(GetCategories().Select(x => new SelectListItem
    {
        Value = x.Id.ToString(),
        Text = x.Name
    });
