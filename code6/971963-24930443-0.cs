    // Add PatientSession via POST
    public class PatientSessionADD : IReturn<PatientSessionResponseId>
    {
        public int PatientSessionId { get; set; }
        public int ByPatientId { get; set; }
        public DateTime PatientStartSessionTime { get; set; }
        public int PatientStartSessionByUserId { get; set; }
        public DateTime PatientEndSessionTime { get; set; }
        public int PatientEndSessionByUserId { get; set; }
    }
    public class PatientSessionResponseId
    {
        public int PatientSessionId { get; set; }
    }
    
    public object Post(PatientSessionADD request)
        {
            var p =new PatientSession()
            {
                    ByPatientId = request.ByPatientId,
                    PatientStartSessionTime = request.PatientStartSessionTime,
                    PatientStartSessionByUserId = request.PatientStartSessionByUserId
            };
 
            return new PatientSessionResponseId
            {
                PatientSessionID = Convert.ToInt16( Db.Insert<PatientSession>(p, selectIdentity: true) )
            };
        }
