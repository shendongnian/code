    var result =
        (
            from patient in patientList
            group patient by patient.PatientID into g
            from p in g
            select new { g.Key, List = p.CaseList.Select(c => c.CaseType).Distinct() }
        ).ToDictionary(kv => kv.Key, kv => kv.List);
    foreach (var item in result)
    {
        Console.WriteLine("Patient {0} has the following cases:", item.Key);
        foreach (var type in item.Value)
        {
            Console.WriteLine("\t{0}", type);
        }
    }
