    public void Save(User saveThis)
    {
        var user_index = _userList
            .Select((item, index) => new {Item = item, Index = index})
            .Where(u => u.Item.RowId == saveThis.RowId)
            .Select(u => (int?)u.Index) //We case to int? to be able to handle the case where the user it not found if we want
            .FirstOrDefault();
        if(user_index == null) //We can handle the case if the user is not found
            return;
        
        var result = Mapper.DynamicMap<User>(saveThis);
        _userList[user_index.Value] = result;
    }
