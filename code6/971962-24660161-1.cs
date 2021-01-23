    public object Any(AddPatientSession request)
    {
        var model = request.ConvertTo<PatientSession>();
        return new {
            PatientSessionId = Db.Insert(model, selectIdentity: true);
        }
    }
