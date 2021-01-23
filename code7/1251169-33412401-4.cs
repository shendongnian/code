	var navigationPermissions = DbContext.NavigationItems
										.Where(x => x.MenuTypeId == (int) menuType && 
												!x.IsDeleted)
										.SelectMany(ni => ni.NavigationItemsPermissions)
										.Where(np => roleIds.Contains(np.RoleId))
										.ToList();
