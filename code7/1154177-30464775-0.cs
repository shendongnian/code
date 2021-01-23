    public class StudentInformation
    {
        public int StudentId { get; set; }
        public bool CanChangeBus { get; set; }
        public List<int> AvailableBuses { get; set; }
    }
    
    public class BusChangeRequestModel
    {
        public int StudentId { get; set; }
    }
    
    //I don't know what is expected as a repsonse?  Is StudentInfromation really the correct response
    //or is something like "Accepted", "rejected", Fail...???
    public class BusChangeResponseModel
    {
        public StudentInformation StudentInfo { get; set; }
    }
