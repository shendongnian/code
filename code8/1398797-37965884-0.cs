        private static void Main(string[] args)
        {
            Dictionary<int, Employee> d1 = new Dictionary<int, Employee>();
            d1.Add(1, new Employee { Name = "Amol" });
            List<Employee> lstEmps = new List<Employee>();
            Employee emp = null;
            for (int i = 0; i < 2; i++)
            {
                emp = new Employee();
                emp.Name = d1[1].Name;
                emp.ReqId = i;
                lstEmps.Add(emp);
            }
        }
