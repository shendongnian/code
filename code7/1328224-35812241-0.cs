    [DataContract(Namespace = "http://www.ffffff.org/uuu/")]
    [KnownType(typeof(NotifRQ))] // add NotifRQ as a known type
    public class HotelResNotifRQ
    {
        public HotelResNotifRQ()
        {
            NotifRQ = new NotifRQ();
        }
        
        ...
