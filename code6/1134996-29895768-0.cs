        [XmlRoot("AdonisHotelSearchCriteriaDTO")]
        public class AdonisHotelSearchCriteriaDTO
        {
            public string CheckInDate { get; set; }
            public string CheckOutDate { get; set; }
            public string CityID { get; set; }
            public string CountryID { get; set; }
            public string HotelID { get; set; }
            public string NationalityCode { get; set; }
            public PaginationData PaginationData { get; set; }
            public RoomCriteria RoomCriteria { get; set; }
            public Credentials Credentials { get; set; }
        }
        [XmlRoot("PaginationData")]
        public class PaginationData
        {
            public int PageNumber { get; set; }
            public int ItemsPerPage { get; set; }
        }
        [XmlRoot("RoomCriteria")]
        public class RoomCriteria
        {
            RoomCriteriaDTO RoomCriteriaDTO { get; set; } 
        }
        [XmlRoot("RoomCriteriaDTO")]
        public class RoomCriteriaDTO
        {
            public int AdultCount { get; set; }
            public int RoomCount { get; set; }
            public int ChildCount { get; set; }
        }
        [XmlRoot("Credentials")]
        public class Credentials
        {
            public int clientID { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }
