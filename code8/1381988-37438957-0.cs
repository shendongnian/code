    public class DepartmentByNameComparer : IEqualityComparer<Department>
    {
        public bool Equals(Department x, Department y)
        {
            return x.Name == y.Name;
        }
        public int GetHashCode(Department obj)
        {
            return obj.Name.GetHashCode();
        }
    }
