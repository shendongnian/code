    // first inner join
    var query = (from R1 in Tasks
    join R2 in ProjectTasks on R1.Id equals R2.TaskId into Group1
    
    // second left join
    from T1 in Group1.DefaultIfEmpty() 
    join R3 in (from t in Timelines where t.Type == 3 select t) on T1.Id equals R3.TypeId into Group2
    
    // third left join
    from T2 in Group2.DefaultIfEmpty()
    join R4 in (from d in Durations where d.Type == 3 select d) on T2.Id equals R4.TypeId
    
    // still not sure to determine where condition here...
    where T2.ProjectId == 1 // join result condition
    
    select new {
        Id = T1.Id.ToString().Concat("T"), // assume Tasks.Id is an int identity column converted to String value
        Name = T1.Name,
        Description = T1.Description,
        Priority = T1.Priority,
        Stage = T1.Stage,
        Status = T1.Status,
        CreatorId = T1.CreatorId,
        ProjectId = T1.ProjectId,
        StartDate = T2.StartDate,
        EndDate = T2.EndDate,
        LatestEndDate = T2.LatestEndDate,
        EarliestStartDate = T2.EarliestStartDate,
        ActualStart = T2.ActualStart,
        ActualEnd = T2.ActualEnd,
        RemTime = T2.RemTime,
        ReshowDate = T2.ReshowDate,
        Completed = T2.Completed,
        ActualDuration = R4.ActualDuration,
        ActualDurationPlanned = R4.ActualDurationPlanned
    }).ToList();
