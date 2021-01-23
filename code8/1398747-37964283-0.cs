    public static class ExtensionMethods
    {
        public static string[] GetByShiftCount(this List<EmployeeSchedule> list, string shift, Func<int, bool> filter)
        {
            return list.Where(x => x.Shift == shift)
                       .GroupBy(x => x.EmpId)
                       .Where(g => filter(g.Count()))
                       .Select(g => g.Key)
                       .ToArray();
        }
    }
