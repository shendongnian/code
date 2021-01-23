                var UserId = User.Identity.GetUserId();
                try
                {
                    user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
                var userInfo = AuthContext.UserInfo.
                       FirstOrDefault(u => u.Id == user.UserInfo_Id);
