    conn = DependencyService.Get().GetConnection();
    conn.CreateTable();
    var patientToInsert = new PatientDB();
    patientToInsert.ID = pat.ID;
    patientToInsert.Name = pat.Name;
    patiendToInsert.PatientVitals = new List();
    foreach (var vital in pat.Vitals)
    {
        var vitalToInsert = new VitalsDB();
        vitalToInsert.PatientVitalID = vital.PatientVitalsID;
        vitalToInsert.Weight = vital.Weight;
        patiendToInsert.PatientVitals.Add(vitalToInsert);
    }
    conn.Insert(patientToInsert);
