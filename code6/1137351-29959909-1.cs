    public List<UnCompletedJobDetailsBO> RemovePODFromSelectedList(
        List<UnCompletedJobDetailsBO> unCompletedJobDetailsBO)
    {
        foreach (var item in unCompletedJobDetailsBO)
        {
            item.JobList.RemoveAll(x => ((x.AllocationDetailList[0] != null) ?
                x.AllocationDetailList[0].JobType == "D" &&
                    x.AllocationDetailList[0].JobUnCollectedID == null &&
                    x.AllocationDetailList[0].CurrentStatus == 5 :
                x.AllocationDetailList.Count > 1));
        }
        
        return unCompletedJobDetailsBO;
    }
