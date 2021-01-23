    var devices = await DeviceConfigurationDbContext.UserGroupMembershipList
                  .AsNoTracking()
                  .Where(ugml => ugml.UserId == currentUser.Id)
                  .Include(o => o.UserGroup)
                  .ThenInclude(o => o.UserGroupAccessList)
                  .ThenInclude(o => o.DeviceGroup)
                  .ThenInclude(o => o.Devices)
                  .SelectMany(ugml =>  ugml.UserGroup.UserGroupAccessLists
                                           .Select(ugal => ugal.DeviceGroup.Devices)
                  .ToListAsync();
