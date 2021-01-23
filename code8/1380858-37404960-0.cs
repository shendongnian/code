    transactions.AddRange(from task in job.Tasks
                          where task.TaskCharges != null && task.TaskCharges.Any()
                          from tc in task.TaskCharges
                          where tc.IsAccepted
                          select new Transaction {});
    foreach (var task in job.Tasks.Where(task => task.TaskCharges != null && task.TaskCharges.Any())) 
    {
        transactions.AddRange(from tc in task.TaskCharges
                              where tc.IsAccepted
                              select new Transaction {});
    }
