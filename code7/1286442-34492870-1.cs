     public IList<User> GetUser(UserRequestDTO _oUserRequestDTO)
        {
            ///This Implements the DbContext
            DataContext _odb=new DataContext();
        Expression<Func<User, bool>> expresionWhere =a=>a.IsDisable.equals(false);
        
            
        
            if(_oUserRequestDTO.RoleId.HasValue)
            {
    
    Expression<Func<User, bool>> expresionRoleId = UserRequestDTO.RoleId =RoleId  && !Role.IsDisable);
                    expresionWhere= PredicateBuilder.And(expresionWhere, expresionRoleId );
            }
        
            if(_oUserRequestDTO.DepartmentId.HasValue)
            {
    
    Expression<Func<User, bool>> expresionDepartmentId = UserRequestDTO.DepartmentId=DepartmentId && !Role.IsDisable);
                    expresionWhere= PredicateBuilder.And(expresionWhere, expresionDepartmentId );
            }
    
    
            IList<User> UserLst=odb.user.Include("UserRequestDTO").Where(expresionWhere).toList();
            return UserLst;
        }
