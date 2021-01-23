    var result = Project.Select(p => new {
        ProjectName = p.ProjectName, 
        TotalTime = p.TotalTime, 
        CustomColumn = p.TotalTime - p.T_Service_Transactions
           .Sum( t=> t.GivenServiceTime)
    });
