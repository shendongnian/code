    public static int CountEmployeesByName(IEnumerable<string> namesToSearch)
    {
        using (var context = new ApplicationEntities())
        {
              return context.employees
                            .Where(e => namesToSearch.Contains(e.name))
                            .Count();
        }
    }
