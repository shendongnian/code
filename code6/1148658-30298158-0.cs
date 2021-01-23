    sealed class MyComparer : IEqualityComparer<UserGroupMap>
    {
        public bool Equals(UserGroupMap x, UserGroupMap y)
        {
            if (x == null)
                return y == null;
            else if (y == null)
                return false;
            else
                return x.UserId.Equals(y.UserId) 
                     && x.GroupId.Equals(y.GroupId)
                     && x.FormGroupFlag.Equals(y.FormGroupFlag)
                     && x.GroupDescription.Equals(y.GroupDescription)
                     && x.GroupName.Equals(y.GroupName);
        }
    
        public int GetHashCode(UserGroupMap obj)
        {
            return UserGroupMap.UserId.GetHashCode();
        }
    }
