    class Department
    {
        public int DepartmentId { get; private set; }
        public string DepartmentName { get; private set; }
        public Department(int id, string name)
        {
             DepartmentId = id;
             DepartmentName  = name;
        }
    }
