    public List<UserInRoleViewModel> GetUserRoles(long userId, params string[] exludeRoleNames)
                {
                    List<UserInRoleViewModel> results = null;
                IQueryable<UserInRoleViewModel> items = null;
    
                exludeRoleNames = !exludeRoleNames.Any() ? new string[] { } : exludeRoleNames; // a MUST
                Expression<Func<UserRoleInApplication, bool>> predicate = x => !exludeRoleNames.Contains(x.UserRole.RoleName);
    
                items = from uir in _repository.GetQuery<UserInRole>(x => x.UserId == userId)
                        join ura in _repository.GetQuery<UserRoleInApplication>(predicate)
                                on uir.UserRoleInApplicationId equals ura.UserRoleInApplicationId
                                into g
                        from item in g
                        select new UserInRoleViewModel
                        {
                            UserInRoleId = uir.UserInRoleId,
                            UserId = uir.UserId,
                            UserRoleInApplicationId = uir.UserRoleInApplicationId
                        };
                
                if (items != null && items.Any())
                {
                    results = new List<UserInRoleViewModel>();
                    results = items.ToList();
                }
    
                return results;
               }
