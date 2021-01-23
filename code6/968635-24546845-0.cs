    var naId = UnitOfWork.SalesPhases.FirstOrDefault(p => p.PhaseName =="NA").SalesPhaseId;
    var rejectedId = UnitOfWork.SalesPhases.FirstOrDefault(p => p.PhaseName =="Rejected").SalesPhaseId;
    var data = UnitOfWork.Leads.Query().AsQueryable()
    .Where(p =>(p.SalesPhaseId == naId || p.SalesPhaseId == rejectedId) &&
    p.CreatedDate>= fromDate.Date && p.CreatedDate <= toDate.Date).Select(m =>
        new
        {
        m.LeadId,
        m.LeadOwnerId,
        m.SalesPhaseId,
        m.LeadActivities,
        m.Employee,
        m.SalesPhase,
        m.CompanyName,
        m.CreatedDate,
        m.LeadHistories,
        m.LeadAddresses
        }).ToList();
