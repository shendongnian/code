    [Authorize]
    public IActionResult Edit(UserViewModel model) {
        if(model.Id != this.CurrentlyLoggedUser.Id) { 
            return this.RedirectToAction(...);
        }
    
        var userService = new UserService(); // inject maybe
        userService.EditById(model.Id, model);
    
        return this.View();
    }
