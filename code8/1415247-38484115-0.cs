    public static IEnumerable<string> GetTitles2(WorkItemCollection workItemList)
    {
        return workItemList.OfType<WorkItem>()
                           .Select(item => item.Fields["Title"].Value.ToString());
    }
