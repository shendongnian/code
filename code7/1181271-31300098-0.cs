    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
    }
    
    public class Teacher : Person 
    {
        public string RoomNumber { get; set; }
        public DateTime HireDate { get; set; }
    }
    
    public class Student : Person
    {
        public string HomeRoomNumber { get; set; }
        public string LockerNumber { get; set; }
    }
