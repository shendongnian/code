    var query =
    (
    from p in db.PatientTable
    where p.Status = "Active"
    group p by p.LivingSpace into g
    select new { LivingSpace = g.Key, Count = g.Count() }
    )
    .Concat
    (
    from p in db.PatientTable
    group p by "SUM" into g
    select new { LivingSpace = g.Key, Count = g.Count() }
    );
