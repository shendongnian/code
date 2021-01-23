    List<string> GroupNames = new List<string>();
    GroupNames.AddRange(ADConnect.ADConnect.GetGroups(adusername));
    List<string> FilteredBoardTestingGroup = new List<string>();
    List<string> FilteredBoardAdminGroup = new List<string>();
    
    var FilteredName = new String[] { "Board Testing" };
    var names = GroupNames.Where(t => FilteredName.Any(c => t.Contains(c)));
    FilteredBoardTestingGroup.AddRange(names);
    FilteredName = new String[] { "Board Testing Admin" };
    names = GroupNames.Where(t => FilteredName.Any(c => t.Contains(c)));
    FilteredBoardAdminGroup.AddRange(names);
    cmbgroup1.DataSource = FilteredBoardTestingGroup;
    cmbgroup2.DataSource = FilteredBoardAdminGroup;
