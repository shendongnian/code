    // Creates IEnumerable<DataRow>
    
    var taskDataTableEnumerable = taskDataTable.AsEnumerable();
    
    List<Task> myTaskList =
        (from item in taskDataTableEnumerable
         select new Task{
             Description = item.Field<string>("DescriptionColumnName"),
             StartDate = item.Field<DateTime>("StartDateColumnName"),
             EndDate = item.Field<DateTime>("EndDateColumnName")
        }).ToList();
