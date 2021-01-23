    public class BasicStudentInformation
    {
        public int StudentId { get; set; }
    }
    
    public class StudentInformation : BasicStudentinformation
    {
        public bool CanChangeBus { get; set; }
        public List<int> AvailableBuses { get; set; }
    }
    
    public class BusChangeRequestModel
    {
        public BasicStudentInformation StudentInfo { get; set; }
        ...
        ...
    }
    
    public class BusChangeResponseModel
    {
        public StudentInformation StudentInfo { get; set; }
        ...
    }
