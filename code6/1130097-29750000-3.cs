    public class Hotel
        {
            public string HotelCode { get; set; }
            public string HotelName { get; set; }
            public List<RoomType> RoomTypes { get; set; }
            public List<availability_group> AvailabilityGroup { get; set; }
        }
    
        public class RoomType
        {
            public string RoomTypeCode { get; set; }
            public string RoomTypeName { get; set; }
        }
    public class availability_group
            {
                public string AvailabilityGroupCode { get; set; }
                public string AvailabilityGroupName { get; set; }
            }
