    public static class EmployeeExtensions
    {
        public static List<Employee> ToClonedList(this IEnumerable<Employee> source)
        {
            return source.Select(employee => employee.Clone() as Employee).ToList();
        }
    }
