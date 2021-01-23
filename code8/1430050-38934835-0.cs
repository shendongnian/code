    List<SelectListItem> roles = new List<SelectListItem>();     
    roles = Enum.GetNames(typeof(OverWatchRoles))
                     .Where(f=>f!=OverWatchRoles.Developer.ToString())
                     .Select(f => new SelectListItem { Value = f, Text = f }).ToList();
    ViewBag.Roles = roles;
