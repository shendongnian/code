    return (from ta in tee.tblReg select new { ta.Region, ta.StartDate, ta.EndDate }).
    Select(data => new chart_project.tblRegion_Uni
    {
    Region = ta.Region, 
    StartDate = ta.StartDate, 
    EndDate = ta.EndDate
    )}.ToList();
