    [XmlRoot("employee")]
    public class EmployeesModel
    {
        [Required]
        [DisplayName("Name: ")]
        [XmlElement("employeeName")]
        public string employeeName { get; set; }
    
        [Required]
        [DisplayName("Position: ")]
        [XmlElement("employeePosition")]
        public string employeePosition { get; set; }
    
        //etc
    }
