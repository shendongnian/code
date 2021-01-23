    ViewBag.Category.Select(c => new SelectListItem
    {
        Text = c.Text,
        Value = c.Value,
        Selected = c.SomeValue == SomeCondition
    });
