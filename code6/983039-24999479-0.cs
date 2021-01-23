    public class CallLogInformation
    {
        public enum CallType { INCOMING, OUTGOING, MISSED, UNKNOWN };
        public string contactNameOrPhoneNumber { get; set;}
        public ContactInformation contactInformation { get; set;}
        public CallType callType { get; set;}
        public long date { get; set;}
        public int callDuration { get; set;}
    }
