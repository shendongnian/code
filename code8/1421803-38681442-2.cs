    protected async Task<bool> IsEducationGroup(AuthorizationHandlerContext context)
    { 
    await Task.Run((){
    
                var userId = context.User.Identity.Name;
                ApplicationUser u = await _userManager.FindByNameAsync(userId);
                if (u.Group == 3 || u.Group == 4)
                {
                    return true;
                }
                return false;
            }
    
        })
