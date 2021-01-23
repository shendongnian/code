    class GroupWithPrimary {
        public string Group {get;}
        public string Primary {get;}
        public GroupWithPrimary(string group, string primary) {
            Group = group;
            Primary = primary;
        }
    }
    private string GetFirstSelectedUser(GroupWithPrimary gp) {
        var users = gp.Group.Trim().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        return users.FirstOrDefault(user => GlobalSettings.Users.Find(x => x.Name == user && x.Selected) != null) ?? gp.Primary
    }
    allRMsColumn.GroupKeyGetter = delegate(object rowObject) {
        return GetFirstSelectedUser(((Tenant)rowObject).RM);
    };
    allFMsColumn.GroupKeyGetter = delegate(object rowObject) {
        return GetFirstSelectedUser(((Tenant)rowObject).FM);
    };
    allFEsColumn.GroupKeyGetter = delegate(object rowObject) {
        return GetFirstSelectedUser(((Tenant)rowObject).FE);
    };
