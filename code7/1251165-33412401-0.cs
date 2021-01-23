	public List<NavigationItem> GetNavigationItems(MenuType menuType, List<int> roleIds)
	{
		var navigationItems = DbContext.NavigationItems
											.Where(x => x.MenuTypeId == (int) menuType && 
													!x.IsDeleted && 
													x.NavigationItemsPermissions.Any(r => roleIds.Contains(r.RoleId)));
		return navigationItems;
	}
