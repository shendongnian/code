    public class Program
    {
        public static void Main()
        {
            Employee employee = new Employee();
            employee.Name = "Ram";
            employee.Id = 77;
            employee.Child = new Family() { ChildName = "Lava" };
            GetPropertyValue(employee, "employee.Child.ChildName");
        }
        public class Family
        {
            public string ChildName { get; set; }
        }
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Family Child { get; set; }
        }
        public static object GetPropertyValue(object src, string propName)
        {
            string[] nameParts = propName.Split('.');
            
            if (nameParts.Length == 1)
            {
                return src.GetType().GetRuntimeProperty(propName).GetValue(src, null);
            }
            nameParts = nameParts.Skip(1).ToArray();
            foreach (String part in nameParts)
            {
                if (src == null) { return null; }
                Type type = src.GetType();
                PropertyInfo info = type.GetRuntimeProperty(part);
                if (info == null)
                { return null; }
                src = info.GetValue(src, null);
            }
            return src;
        }
