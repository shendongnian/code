    public class CallDetails
    {
        public Call entityCall { get; set;}
        public int CallId => entityCall.CallId;
        public DateTime callTime {
                get{ return entityCall.callTime;}
                set{ entityCall.callTime = value;}
            }
        public string TypeOfPhone => entityCall.PhoneType.TypeOfPhone;
    }
