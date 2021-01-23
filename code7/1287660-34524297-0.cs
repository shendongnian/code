    foreach (var entity in elist)
    {
        lateList.Add(new Employee()
        {
            InTime = entity.InTime
            //Other properties too
        });
    }
