    var schemes = schemeManager.GetUserSchemes(this.UserId);
    var selectListItems = schemes.Select(x => new SelectListItem()
    {
        Value = x.Id.ToString(), 
        Text = x.Name
    });
    var vm = new UserSchemesViewModel()
    {
        Schemes = selectListItems,
        SchemeId = 2
    };
    return PartialView("_UserSchemes", vm);
