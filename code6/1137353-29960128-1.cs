       unCompletedJobDetailsBO.ForEach(y => y.JobList.RemoveAll(x => ((x.AllocationDetailList != null && x.AllocationDetailList.Count>0) 
                                                                             ?
                                                                             x.AllocationDetailList[0].JobType == "D"
                                                                               && x.AllocationDetailList[0].JobUnCollectedID == null
                                                                               && x.AllocationDetailList[0].CurrentStatus == "5" 
                                                                             :
                                                                            x.AllocationDetailList.Count > 1
                                                                             )
                                                                       ));
   
  
