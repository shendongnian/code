    public class RSVPService : IRSVP
    {
        [WebGet]
        public bool Attending()
            return true;
        [WebGet]
        public bool NotAttending()
            return true;
    }
