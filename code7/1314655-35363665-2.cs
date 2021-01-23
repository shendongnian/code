    public class VM_StudentFull : VM_Student
    {
      //Only Add the Extra Fields here, the StudentFull inherits
      //the other attributes and validation
      [StringLength(15)]
      [DataType(DataType.PhoneNumber)]
      public string Mobile { get; set; }
      [DataType(DataType.EmailAddress)]
      public string Email { get; set; }
      [DataType(DataType.DateTime)]
      public DateTime DateOfBirth { get; set; }          
    }
    public class VM_StudentMarks : VM_Student
    {
      //Only Add the Extra Fields here again,
      //the StudentMarks inherits the other attributes and validation
      [Range(5,12)]
      public int ClassId { get; set; }
      [Range(0,1000)]
      public int MarksObtained { get; set; }
      [DataType(DataType.DateTime)]           
    }
