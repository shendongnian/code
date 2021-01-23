    private void SetUpUserType<T>(T model) where T : ViewModelBase
    {
        var usertypes = GetuserTypes();
        model.UserTypes = new List<SelectListItem> { };
        usertypes.ForEach(t => model.UserTypes.Add(new SelectListItem() { Text = t.Text, Value = t.Value }));
    }
