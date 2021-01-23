    public class Program
    {
        public static void Main(string[] args)
        {
            Employee[] employees = new Employee[123]
                .Select(employee => new Employee()).ToArray();
    
            DayOffAllocator dayOffAllocator = new DayOffAllocator();
            foreach(var employee in employees)
            {
                dayOffAllocator.AllocateDayOff(employee);
            }
            Dictionary<DayOfWeek, int> dist = ((DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
                .ToDictionary(k => k, v => employees.Count(x => x.DayOff == v));
        }
    }
