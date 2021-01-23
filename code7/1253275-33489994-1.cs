    protected void Page_Load(object sender, EventArgs e)
        {
            List<Employee> MyEmployees = new List<Employee>();
            
            MyEmployees.Add(new Employee(1, "User 1", "Path1,Path1,Path2,Path2,Path2,Path3"));
            Response.Write("Employee 1 Information:<br />");
            WriteEmployeeToScreen(MyEmployees[0]);
        }
        protected void WriteEmployeeToScreen(Employee ThisEmployee)
        {
            System.Text.StringBuilder paths = new System.Text.StringBuilder();
            Response.Write(string.Format(
                "{1} ({0})<br />",
                ThisEmployee.EmpId,
                HttpUtility.HtmlEncode(ThisEmployee.EmpName)));
            foreach (string path in ThisEmployee.PathSuffix)
            {
                paths.Append(string.Format(", {0}", path));
            }
            if (paths.Length > 0)
            {
                Response.Write(string.Format("Paths: {0}", paths.ToString().Substring(2)));
            }
        }
