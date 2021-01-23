    public class Hotel
        {
            public string HotelCode { get; set; }
            public string HotelName { get; set; }
            public List<RoomType> RoomTypes { get; set; }
        }
    
        public class RoomType
        {
            public string RoomTypeCode { get; set; }
            public string RoomTypeName { get; set; }
        }
