    [HttpGet]
    [Route("GetUserRoles")]
    public async Task<ApiResponse<List<RoleViewModel>>> GetUserRoles(string userName)
    {
        try
        {
            // Get the user in question
            var aspUser = (from u in _db.AspNetUsers
                           where u.UserName == userName
                           select u).FirstOrDefaultAsync();
            // Check if the user was found
            if (aspUser == null)
            {
                throw new Exception("User was not found");
            }
            // Get the roles associated with that user
            var userRoles = await UserManager.GetRolesAsync(aspUser.Result.Id.ToString());
                
            // Setup a RoleViewModel list of roles and iterate through userRoles adding them to the list
            List<RoleViewModel> roleList = new List<RoleViewModel>();
            foreach (var u in userRoles)
            {
                var item = new RoleViewModel { Name = u };
                roleList.Add(item);
            }
            return new ApiResponse<List<RoleViewModel>> { Success = true, Result = roleList };
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<RoleViewModel>> { Success = false, Message = ex.Message };
        }
    }
