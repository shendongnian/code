    var PermissionsCommitList = ValuesGrid.DbContext
    	.USER_PERMISSIONS.Local;
        
    foreach (DataEntity.USER_PERMISSIONS permission in PermissionsCommitList)
    	{
    		UserPermissionsValue ValueToCommit = UserPermissionsList
            .Where(x => x.PERMISSION_ID == permission.PERMISSION_ID)
            .First();
    		
    		permission.VALUE = ValueToCommit.VALUE;
    	}
    dtgPermissionsSettings.pFormGrid.DataEntityProvider.SaveChanges();
