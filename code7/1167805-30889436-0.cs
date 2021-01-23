    public ActionResult Index(AgentReportViewModel vm)
    {
        var b = Agent.GetAgents();
        vm.Agents = vm.SortAscending 
            ? b.OrderBy(x => GetValueByColumn(x, vm.SortByColumn))
            : b.OrderByDescending(x => GetValueByColumn(x, vm.SortByColumn));
        return View(vm);
    }
 
    public object GetValueByColumn<T>(T x, string columnStr)
    {
        // Consider caching the property info, as this is a heavy call.
        var propertyInfo = x.GetType().GetProperty(columnStr);    
        return propertyInfo.GetValue(x, null);
    }
