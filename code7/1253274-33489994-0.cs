    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        
        public List<string> PathSuffix { get; set; }
        public Employee(int ID, string Name, string PathCSV)
        {
            EmpId = ID;
            EmpName = Name;
            PathSuffix = new List<string>();
            foreach (string path in PathCSV.Split(','))
            {
                if (string.IsNullOrEmpty(path) == false && path.Trim().Length > 0)
                {
                    if (PathSuffix.Exists(x => x.ToLower() == path.Trim().ToLower()) == false)
                    {
                        PathSuffix.Add(path.Trim());
                    }
                }
            }
        }
    }
