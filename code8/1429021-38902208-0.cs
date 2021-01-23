    SearchCriteria{
        public string SearchUsername { get; set; }
        public string SearchProfile { get; set; }
        public SearchInterest SearchInterest { get; set; }
    }
    public class ProfileSearchDto {
        public SearchCriteria searchCriteria {get; set;}
    }
    public class Broadcast {
        public SearchCriteria searchCriteria {get; set;}
    }
