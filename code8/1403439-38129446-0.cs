    [HttpGet]
    [Route("GetUserRoles")]
    public async Task<ApiResponse<List<RoleViewModel>>> GetUserRoles(string userName)
    {
        try
        {
            #region Alternate logic
            // Alternate route to the same results
            //var userTest = (from user in _db.AspNetUsers
            //            where user.UserName == userName
            //            select user).First();
            //var linqQueriedRoles = await (from roles in userTest.AspNetRoles
            //                        where roles.Id == userTest.Id
            //                        select new RoleViewModel { Name = roles.Name }).AsQueryable().ToListAsync();
            #endregion
            var userRoles = await (_db.AspNetUsers.FirstOrDefault(u => u.UserName == userName).AspNetRoles).AsQueryable().Select(r => new RoleViewModel { Id = r.Id, Name = r.Name }).ToListAsync();
            return new ApiResponse<List<RoleViewModel>> { Success = true, Result = userRoles };
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<RoleViewModel>> { Success = false, Message = ex.Message };
        }
    }
