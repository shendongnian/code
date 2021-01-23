    [ChildActionOnly]
    public PartialViewResult Render() {
    var userId = Session["some_key"];
    var model = _userMenuService.GetModelForUserId(userId);
    return PartialView(model);
    }
