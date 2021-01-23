    public void Sort() 
    {
            List<DataOption> TheListContainingTheCategories = ...;
            Dictionary<int, string> lookup = TheListContainingTheCategories.ToDictionary(x => x.id, x => x.name);
            List<CustomTask> listTempTasks = new List<CustomTask>();
            var listTasksSorted = listTempTasks.OrderBy(c => lookup[c.categoryid]).ToList();
    }
