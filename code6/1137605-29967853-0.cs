    Employee employee = Repository.Employees.Include("Dep").Single(p => p.Id ==<some id>);
    var entry = context.Entry(employee);
    entry.Property(e => e.name ).IsModified = true;
    // other changed properties
    db.SaveChanges();
