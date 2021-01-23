    public void GetGroupTree()
    {
        List<DeviceGroup> rootgroup = db.DeviceGroups.Where(a => a.ParentGroupID == 0).ToList();
        foreach (var item in rootgroup)
            GetGroupTree(item);
    }
    public void GetGroupTree(DeviceGroup group)
    {
        var subGroups = db.DeviceGroups.Where(a => a.ParentGroupID == group.GroupID).ToList();
        if (subGroups.Count > 0)
        {
            group.SubGroup = subGroups;
            foreach (var item in group.SubGroup)
                GetGroupTree(item);
        }
    }
