    protected int getManagerDoneCount(string managerName)
    {
        using (var context = new InfoDBContext())
        {
            int managerDoneCount = context.InfoSet
                    .Where(x => x.ww >= wwStartSelected &&
                                x.ww <= wwEndSelected && 
                                x.manager == managerName &&
                                x.status == "Done")
                    .GroupBy(x => x.ww)
                    .Count();
    
            return managerDoneCount;
        }
    }
