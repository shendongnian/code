    [DataContract(IsReference=true)]
    public class Department
    {
        [DataMember]
        public string DepartmentName { get; set; }
        [DataMember]
        public List<Employee> employees { get; set; }
    }
    [DataContract(IsReference=true)]
    public class Employee
    {
        [DataMember]
        public string username { set; get; }
        
        [DataMember]
        public Department department { get; set; }
        
    }
