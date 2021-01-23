    public class HotelAvailNotifRQ : IHotelAvailNotifRQ
    {
       [MarshalAs(UnmanagedType.Interface)]
       public IAvailStatusMessage[] AvailStatusMessagesField;
       public IAvailStatusMessage[] AvailStatusMessages
       {
        get { return AvailStatusMessagesField; }
        set { AvailStatusMessagesField = value; }
       }
    }
