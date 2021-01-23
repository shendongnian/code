    public IEnumerable<SelectListItem> GetCategoriesSelectList()
    {
        var categories = _context.Category;
        // Initialise list and add first "All" item
        List<SelectListItem> options = new List<SelectListItem>
        {
            new SelectListItem(){ Value = "0", Text = "All" }
        };
        // Get the top level parents
        var parents = categories.Where(x => x.ParentId == null);
        foreach (var parent in parents)
        {
            // Add SelectListItem for the parent
            options.Add(new SelectListItem()
            {
                Value = parent.Id.ToString(),
                Text = parent.Name
            });
            // Get the child items associated with the parent
            var children = products.Where(x => x.ParentId == parent.Id);
            // Add SelectListItem for each child
            foreach (var child in children)
            {
                options.Add(new SelectListItem()
                { 
                    Value = child.Id.ToString(),
                    Text = string.Format("--{0}",child.Name)
                });
            }
        }
        return options;
    }
