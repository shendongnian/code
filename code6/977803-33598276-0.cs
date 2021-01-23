        public IEnumerable<GroupAuthority> GroupAuthoritysSorted 
        { 
            get 
            { 
                return GroupAuthoritys.OrderBy(x => x.Group.ID == 0)
                                      .ThenBy(x => x.Group.Name); 
            } 
        }
