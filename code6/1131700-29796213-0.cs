    while (sdr.Read())
    {
        Group groupclass = new Group();
        groupclass.groupName = sdr.GetString("group_name");
        groupclass.groupID = sdr.GetString("ID");
        group.Add(groupclass);
    }
