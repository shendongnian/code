    IEnumerable<Staff> staffList = (from s in db.Staffs
                         from d in db.Departments
                         where s.DeptID == d.DeptID
                         select new
                         {
                             name = s.Name,
                             email = s.Email,
                             department = s.Department,
                             site = d.Site
                         }).AsEnumerable()
                           .Select(x => new new Staff 
                              {
                                 Name = x.name,
                                 Email= x.email,
                                 Department = x.department,
                                 Site = x.site
                              });
                    
