    private static IEnumerable<XElement> CreateEmployeeElements(Employee employee)
    {
        yield return new XElement("Emp", /* content */);
        if (employee.ClockGroup.Count == 0)
        {
            yield return new XElement("Group", new XAttribute("groupId", 2));
        }
        // and so on for more element conditions
    }
