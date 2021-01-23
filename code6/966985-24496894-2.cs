    DataContext dc = new DataContext(ConnectionString);
    var result = dc.UserInfos.Join(dc.UserInfos, 
                                   a => new { strBusinesssType == a.strBusinessType, ..., strSSN = a.strSSN }, 
                                   b => new { strBusinesssType == b.strBusinessType, ..., strSSN = b.strSSN }, 
                                   (a, b) => new { aTable = a, bTable = b })
                             .Where(o => o.bTable.liUserKey == @UserID && o.aTable.fActive == 1 && o.aTable.fAuthenticated == 1)
                             .Select(o => o.aTable.liProviderKey).Distinct();
