    var listOfEmployeeCV = from cvs in _context.EmployeeCvs.Include(x => x.Employee).Include(x=>x.Tags)
                                       .Include(x=>x.ProjectExperiences)
                                  where _context.Employees.Any(
                                        e => e.FirstName.Contains(SearchQuery.Keyword)
                                        && e.Id == cvs.Employee.Id
                                  ) || (_context.Tags.Any(t=>t.Title.Contains(SearchQuery.Keyword) && cvs.Tags.Contains(t)))
                                    || (_context.ProjectExperiences.Any(pe=>(pe.ProjectTitle.Contains(SearchQuery.Keyword) 
                                    || pe.Description.Contains(SearchQuery.Keyword)) && 
                                    cvs.ProjectExperiences.Contains(pe)))
                                   select new
                                   EmployeeCvDTO
                                   {
                                       Employee = new EmployeeDTO
                                       {
                                           FirstName = cvs.Employee.FirstName,
                                           LastName = cvs.Employee.LastName,
                                           EnterpriseId = cvs.Employee.EnterpriseId,
                                           Level = cvs.Employee.Level
                                           //ProfileImageData = x.Employee.ProfileImageData
                                       },
                                       Tags = cvs.Tags,
                                       ProjectExperiences = cvs.ProjectExperiences,
                                   };
