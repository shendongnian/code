    public IList<User> GetUser(UserRequestDTO _oUserRequestDTO)
    {
        DataContext _odb = new DataContext();
    
        var users =_odb.user.where(a=>a.IsDisable.equals(false));
        var query = from qu in users
                    from role in _odb.Role.where(a=>a.Id.equals(qu.RoleId))
                    select new { User = qu, Role = role };
    
    
        if(_oUserRequestDTO.RoleId.HasValue)
        {
            query = from o in query
                    where o.Role.Id.equals(RoleId) && o.Role.IsDisable.equals(false))
                    select o;
        }
    
        if(_oUserRequestDTO.DepartmentId.HasValue)
        {
            query = from o in query
                    where o.Role.Department.Id.equals(DepartmentId) && o.Role.IsDisable.equals(false))
                    select o;
        }
        return query.Select(o => o.User).ToList();
    }
