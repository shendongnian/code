                var theIDsToInclude = (from id in this.ObjectContext.Identities
                                    join idGroups in this.ObjectContext.IdentityGroups
                                        on id.IdentityID equals idGroups.IdentityID
                                    join groupSup in this.ObjectContext.GroupSupervisors.Where(r => r.SupervisorID == loggedInID)
                                        on idGroups.GroupID equals groupSup.GroupID
                                    select id.IdentityID).Distinct().ToList();
                theData = (from urls in this.ObjectContext.Activities.AsExpandable().Where(predicateA)
                                      .Where(r => (r.StartDate >= beginDate && r.StartDate <= endDate) ||
                                            (r.EndDate >= beginDate && r.EndDate <= endDate) ||
                                            (r.StartDate <= beginDate && r.EndDate >= endDate))
                                            .Where(r=> theIDsToInclude.Contains(r.IdentityID))
                           //join idGroups in this.ObjectContext.IdentityGroups on urls.IdentityID equals idGroups.IdentityID
                           //join groupSup in this.ObjectContext.GroupSupervisors.Where(r => r.SupervisorID == loggedInID) on idGroups.GroupID equals groupSup.GroupID
                           join programs in progs on urls.ProcessName.ToUpper() equals programs.ProcessName.ToUpper() into jt
                           from jt1 in jt.DefaultIfEmpty().Where(r => r == null || r.Ignore == false)
                           group urls by new { urls.ProcessName, urls.ContextID, jt1.CustomCategory, jt1.Name } into groupedTable
                           select new ActivityInfoSummary_DTO
                           {
                               recId = Guid.NewGuid(),
                               Context = groupedTable.Key.ProcessName,
                               ContextId = groupedTable.Key.ContextID,
                               FocusCount = groupedTable.Sum(r => r.FocusCount),
                               many more fields...
                           }).ToList();
