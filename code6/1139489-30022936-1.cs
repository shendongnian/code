    int JobNumMax = 0;
    int WSMax  0;
    foreach (var i in SortList)
    {
    	if (JobNumMax >= WSMax)
    	{
    		return i.EndHour = JobNumMax + i.ProcTime;
    	}
    	else if (JobNumMax > 0 && WSMax > 0)
    	{
    		return i.EndHour = WSMax + currentjob.ProcTime;
    	}
    	
    	for (var j = 0; j < SortList.Count; j++)
    	{
    		int JobLNumMaxIndex = SortList.FindLastIndex(order => order.JobNum == i.JobNum);
    		JobNumMax = i.EndHour[JobNumMaxIndex];
    		
    		for (var k = 0; k < SortList.Count; k++)
    		{
    			int WSMaxIndex = SortList.FindLastIndex(order => order.Workstation == i.Workstation);
    			WSMax = i.EndHour[JobNumMaxIndex];
    		}
    	}
    }
