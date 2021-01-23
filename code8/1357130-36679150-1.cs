    [Route("users/edit/{id}/{isUserEdit?}")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UserEdit(UserViewModel vm, bool isUserEdit)
    {
        if(isUserEdit)
        {
           return View(vm);
        }    
        else
        {
            //logic for add user
        }
    }
