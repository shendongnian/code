    foreach (var task in myTasks)
    {
        TaskAbstract instance = (TaskAbstract)task.CreateExport().Value;
    
    // Reflect properties, not all members
        PropertyInfo[] infos = instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Static);
        foreach (PropertyInfo member in infos.Where(x => x.Name.Equals("ResultEnum")))
        {
            var enumValueName = Enum.GetName(member.GetType(), member.GetValue(instance));                  
        }
    }
