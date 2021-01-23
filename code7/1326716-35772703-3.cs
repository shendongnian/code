    var result =
        (
        from patient in patientList
        group patient by patient.PatientID into g
        from patient in g
        from typ in patient.CaseList
        select new { ID = g.Key, Type = typ.CaseType }
        ).Distinct();
    foreach (var item in result)
    {
        Console.WriteLine("Patient {0} has the following case: {1}", item.ID, item.Type);
    }
