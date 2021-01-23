    class PrivilegesComparer : IEqualityComparer<Privileges>
    {
        public bool Equals(Privileges x, Privileges y)
        {
            return x.UserId == y.UserId
                   && x.FormName == y.FormName
                   && x.CompName == y.CompName;
        }
        public int GetHashCode(Privileges obj)
        {
            return (obj.UserId + obj.FormName + obj.CompName).GetHashCode();
        }
    }
