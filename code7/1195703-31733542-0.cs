    public ActionResult Create()
    {
        return View(new MenuItem
        {
            Templates = _yourFilesList.
                .Select(f => new SelectListItem { Text = f.Title })
        });
    }
    [HttpPost]
    public ActionResult Create(MenuItem item)
    {
         var userTemplate=item.PageTemplate; // user's selected item is there
    }
