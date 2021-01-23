    public IEnumerable<SelectListItem> ListGroupEnabled(int? currentGroupId = null)
    {
        return _entities.Groups.Where(
            p =>
                p.IsEnabled ||
                (currentGroupId.HasValue && p.GroupId == currentGroupId.Value)
        ).Select(c => new SelectListItem { Value = c.GroupId.ToString(), Text = c.Name }).ToList();
    }
