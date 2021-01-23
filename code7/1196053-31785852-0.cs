    using (var listService = GetListService(webUri,userName,password))
    {
         listService.GetListAsync(listName, listName);
         listService.GetListCompleted += ProcessListResult;
    }
