        return _context.Users.ToList().Select(users => new SelectListItem
        {
            Text = users.Id.ToString(),
            Value = users.Id.ToString()
        });
    }
