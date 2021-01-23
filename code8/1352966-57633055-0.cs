    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Details(
        SelectedUserRoleViewModel removeRoleViewModel, 
        SelectedRoleViewModel addRoleViewModel,
        UserDetailsSubmitAction submitAction)
    {
        switch (submitAction)
        {
            case UserDetailsSubmitAction.AddRole:
            {
                return await AddRole(addRoleViewModel);
            }
            case UserDetailsSubmitAction.RemoveRole:
            {
                return await RemoveRole(removeRoleViewModel);
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(submitAction), submitAction, null);
        }
    }
    private async Task<IActionResult> RemoveRole(SelectedUserRoleViewModel removeRoleViewModel)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = await _userService.GetDetailsViewModel(removeRoleViewModel.UserId);
            return View(viewModel);
        }
        await _userRoleService.Remove(removeRoleViewModel.SelectedUserRoleId);
        return Redirect(Request.Headers["Referer"].ToString());
    }
    private async Task<IActionResult> AddRole(SelectedRoleViewModel addRoleViewModel)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = await _userService.GetDetailsViewModel(addRoleViewModel.UserId);
            return View(viewModel);
        }
        await _userRoleService.Add(addRoleViewModel);
        return Redirect(Request.Headers["Referer"].ToString());
    }
