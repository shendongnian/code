                var UserId = User.Identity.GetUserId<int>();
                try
                {
                    user = await UserManager.FindByIdAsync(UserId );
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
                var userInfo = AuthContext.UserInfo.
                       FirstOrDefault(u => u.Id == user.UserInfo_Id);
