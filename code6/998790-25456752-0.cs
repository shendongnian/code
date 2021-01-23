    private Group _Group;
    
            public Group ContactGroup
            {
                get
                {
                    return _Group;
                }
                set
                {
                    _Group = value;
                }
            }
    
            public IEnumerable<Group> ContactGroupValues
            {
                get
                {
                    return Enum.GetValues(typeof(Group)).Cast<Group>();
                }
            }
