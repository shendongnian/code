    var attendeeIds = groupActivity.Attendees.Select(u => u.Id).ToList();
    IEnumerable<SelectListItem> items = db.Users.Select(c => new SelectListItem
    {
        Value = c.Id.ToString(),
        Text = c.LastName + ", " + c.FirstName,
        Selected = attendeeIds.Contains(c.Id)
    })
    .OrderBy(q => q.Text);
