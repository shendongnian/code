    [Serializable]
    public class Booking
    {
        [ForeignKey("Guest")]
        public string GuestId { set; get; }
        [NonSerialized]
        User guest;
        public virtual User Guest { set { guest = value; } get { return guest; } }
    }
