    foreach (var prop in vm.GetType()
                           .GetProperties()
                           .Where(x => x.GetCustomAttributes<ExportAttribute>().Any()))
    {
        var list = (IEnumerable<BaseType>) prop.GetValue(vm, null);
        foreach (var item in list)
        {
            // do something
        }
    }
