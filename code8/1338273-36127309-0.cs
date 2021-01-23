    (from st in Context.STopics 
    join at in Context.ATopics  on st.Id equals at.Id
    join p in Context.Students  on new { st.StudentId, p.IsActive }   equals new { p.Id , true}
    join sbu in Context.Sorgs  on new { sbu.BUorgID, sbu.IsActive,sbu.StudentID }  equals new { at.BUorgID , true, 123}
    join bo in Context.BOrgs  on sbu.BUOrgID equals bo.ID
    join ns in Context.Status  on st.SID equals ns.ID
    join pa in Context.Students  on st.NominatedBy equals pa.Email
    select new result()
    {
    DLId = p.Id,
    TopicId = st.Id,
    TopicName = at.Name,
    PrimaryOrg = bo.BusinessUnit,
    StatusId = ns.ID,
    ModifiedBy  = pa.LastName
    })
