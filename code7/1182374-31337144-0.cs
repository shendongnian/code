    static void Main(string[] args)
    {
        List<string> paths = new List<string>() {
            "Employee/Entity/Id",
            "Employee/Entity/Name",
            "Employee/Entity/Address/City",
            "Employee/Entity/Address/State"
        };
        IEnumerable<XElement> result = GroupSteps(from path in paths select path.Split('/'));
        foreach (XElement el in result)
        {
            Console.WriteLine(el);
        }
    }
    private static IEnumerable<XElement> GroupSteps(IEnumerable<IEnumerable<string>> steps)
    {
        return GroupSteps(steps, 1);
    }
    private static IEnumerable<XElement> GroupSteps(IEnumerable<IEnumerable<string>> steps, int level)
    {
        return from step in steps
               group step by step.FirstOrDefault() into g
               select g.Count() > 1 ?
                new XElement("div",
                   new XAttribute("class", "Level" + level),
                   new XElement("div",
                       new XElement("p", g.Key)
                   ),
                   GroupSteps(g.Select(mg => mg.Skip(1)), level + 1)) :
                new XElement("label", g.Key + ": ", new XElement("input", new XAttribute("type", "text")));
    }
