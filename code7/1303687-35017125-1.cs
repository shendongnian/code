    Func<object, object> CreateGroupKeyGetter(Func<Tenant, string> func1, 
               Func<Tenant, string> func2)
    {
        return rowObject=>
                {
                    var users = func1(((Tenant) rowObject)).Trim().Split(new[] ", "}, StringSplitOptions.RemoveEmptyEntries);
                    return users.FirstOrDefault(user => GlobalSettings.Users.Find(x => x.Name == user && x.Selected) != null) ?? func2(((Tenant)rowObject));
                }
    }
    allRMsColumn.GroupKeyGetter = CreateGroupKeyGetter(t=>t.Rms, t=>t.PrimaryRm);
    allFMsColumn.GroupKeyGetter = CreateGroupKeyGetter(t=>t.Fms, t=>t.PrimaryFm);
    allFesColumn.GroupKeyGetter = CreateGroupKeyGetter(t=>t.Fes, t=>t.PrimaryFe);
    }
