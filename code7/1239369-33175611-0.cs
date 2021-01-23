        var Teacher = from c in Container.Teachers
                          select new
                          {
                             Name = c.Name,
                             FatherName = c.FatherName,
                             ContactNo = c.ContactNo,
                             Address = c.Address,
                             Religion = c.Religion,
                             CNIC = c.CNIC,
                             Status = c.Status,
                             UserName = c.UserName,
                             //I had made changes in the following code:
                             Subjects = c.Subjects.Select(s=>s.Subject_Name).FirstOrDefault()
                          };
