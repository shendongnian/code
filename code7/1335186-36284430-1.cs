    [Authorize("Admin")]
    public IActionResult Edit(UserViewModel model) {
        var userService = new UserService(); // inject maybe
        userService.EditById(model.Id, model);
    
        return this.View();
    }
