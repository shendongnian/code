    class EmployeeSummaryEqualityComparer : IEqualityComparer<EmployeeSummary>
    {
        public bool Equals(EmployeeSummary x, EmployeeSummary y)
        {
            if (object.ReferenceEquals(x, null))
                return object.ReferenceEquals(y, null);
            return x.FirstName == y.FirstName &&
                x.LastName == y.LastName;
        }
        public int GetHashCode(EmployeeSummary x)
        {
            unchecked
            {
                var h = 31;   // null checks might not be necessary?
                h = h * 7 + (x.FirstName != null ? x.FirstName.GetHashCode() : 0);
                h = h * 7 + (x.LastName != null ? x.LastName.GetHashCode() : 0);
                return h;
            }
        }
    }
