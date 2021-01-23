    public class UpdateAppointment
    {
        [IgnoreDataMember]
        public bool HasMemberId { get; set; }
        Guid? memberId;
        public Guid? MemberId 
        {
            get { return memberId; }
            set 
            {
                memberId = value;
                HasMemberId = true;
            }
        }
    }
