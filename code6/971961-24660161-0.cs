    public class MyServices : Service
    {
        public object Any(AddPatientSession request)
        {
            var model = request.ConvertTo<PatientSession>();
            return new PatientId {
                PatientSessionId = Db.Insert(model, selectIdentity: true);
            }
        }
    }
