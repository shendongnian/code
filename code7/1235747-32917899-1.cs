    public ActionResult classes(string keyword ="")
    {
        EmployeeContext emp = new EmployeeContext();
        IEnumerable<classlist> asd = (from subj in emp.Subjects
                               join prof in emp.professors on subj.id equals prof.id
                               join dep in emp.departments on prof.id equals dep.id
                               select new classlist()
                               {
                                   id = subj.id,
                                   subj = subj.subj,
                                   days = subj.days,
                                   cstart = subj.cstart,
                                   cend = subj.cend,
                                   units = subj.units,
                                   fname = prof.fname,
                                   lname = prof.lname,
                                   status = prof.status,
                                   department = dep.dname,
                                   isSelected = false
                               });
        //Apply the where clause if required
        if(!string.IsNullOrEmpty(keyword))
            asd = asd.Where(c => c.subj == keyword);
        //Return the materialised list now:
        return View(asd.ToList());
    }
