    public IQueryable<EmployeeBase> Employees() {
        return (
    
        from p in db.EmployeeDetails
        join i in db.EmployeeDept on p.DeptId equals i.DeptId into inst
        from i in inst.DefaultIfEmpty()
        join s in db.Employee on p.EmpId equals s.EmpId into manager
        from s in manager.DefaultIfEmpty()
        join e in db.EmpStatus on p.EnrollmentStatusID equals e.StatusID into estatus
        from e in estatus.DefaultIfEmpty()
        where p.SomeId== id && (p.IsActive == true || p.SomeStatus == null)
        select new EmployeeBase
        {
          //select list common to all queries. 
        });
    }
...
    var awesomeEmployee=Employees().Single(x=>x.name=="Me");
    var listToFire=Employees().OrderByDescending(x=>x.Salary).Take(3);
    var listToPromote=Employees().OrderByDescending(x=>x.Performance).Take(1);
