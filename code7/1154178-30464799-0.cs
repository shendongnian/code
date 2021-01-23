    public class StudentBase
    {
        public int StudentId { get; set; }
    }
    public class StudentInformation : StudentBase
    {
        public bool CanChangeBus { get; set; }
        public List<int> AvailableBuses { get; set; }
    }
    public class BusChangeRequestModel
    {
        public StudentBase StudentInfo { get; set; }
        ...
        ...
    }
    public class BusChangeResponseModel
    {
        public StudentInformation StudentInfo { get; set; }
        ...
    }
